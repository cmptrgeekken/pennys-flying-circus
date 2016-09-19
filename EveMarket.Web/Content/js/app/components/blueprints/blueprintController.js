(function () {
    'use strict';
    angular
        .module('bpApp', ['ngMaterial'])
        .controller('BlueprintController', BlueprintController)
        .filter('orderObjectBy',
            function() {
                return function(items, field, reverse) {
                    var filtered = [];
                    angular.forEach(items,
                        function(item) {
                            filtered.push(item);
                        });
                    filtered.sort(function(a, b) {
                        return (a[field] > b[field] ? 1 : -1);
                    });
                    if (reverse) filtered.reverse();
                    return filtered;
                };
            });


    function BlueprintController($scope, $http) {
        var self = this;

        self.selectedItem = null;
        self.compressMinerals = true;
        self.materialList = {};
        self.bpcList = {};
        self.stationActivities = {};

        self.findBlueprints = findBlueprints;
        self.findSystems = findSystems;
        self.updateSystemRates = updateSystemRates;
        self.addBlueprint = addBlueprint;
        self.calcTabs = printTabs;
        self.refreshMaterials = refreshMaterials;
        self.printTabs = printTabs;
        self.summarizeBlueprints = summarizeBlueprints;

        self.selectedBlueprints = [];

        addBlueprint(24483);

        function updateSystemRates() {
            $http.get('http://api.eve-industry.org/system-cost-index.xml', { params: { name: self.mfgSystem.SystemName } })
                .then(function (response) {
                    var dom = parseXml(response.data);
                    var activities = dom.getElementsByTagName('activity');
                    for (var i = 0; i < activities.length; i++) {
                        var activity = activities[i];
                        self.stationActivities[activity.getAttribute("name")] = parseFloat(activity.innerHTML);
                    }
                });
        }

        function parseXml(xml) {
            var dom;
            if (typeof DOMParser != "undefined") {
                var parser = new DOMParser();
                dom = parser.parseFromString(xml, "text/xml");
            }
            else {
                var doc = new ActiveXObject("Microsoft.XMLDOM");
                doc.async = false;
                dom = doc.loadXML(xml);
            }

            return dom;
        }

        function refreshMaterials(mat) {
            var reducedQty = mat.ReducedQty || mat.Qty;
            var ttlQty = mat.TotalQty || mat.Qty;
            var me = mat.MaterialEfficiency;
            var materials = mat.Materials;

            for (var i = 0; i < materials.length; i++) {
                var childMat = materials[i];

                childMat.TotalQty = childMat.Qty * ttlQty;
                childMat.ReducedQty = reducedQty * Math.ceil(childMat.Qty * (1 - me * .01));

                refreshMaterials(childMat);
            }
        }

        function summarizeBlueprints() {
            var bps = self.selectedBlueprints;

            self.bpcList = {};
            self.materialList = {};

            for (var i = 0; i < bps.length; i++) {
                var bp = bps[i];

                self.bpcList[bp.TypeName] =
                {
                    TypeId: bp.TypeId,
                    TypeName: bp.TypeName,
                    Qty: bp.Qty
                };

                summarizeMaterials(bp);
            }

            calculateJobBaseCosts();

            //calculatePricing();
        }

        function calculateJobBaseCosts() {
            var names = "";
            for (var name in self.bpcList) {
                if (!self.bpcList.hasOwnProperty(name)) continue;

                if (names) names += ",";

                names += name;
            }

            $http.get('http://api.eve-industry.org/job-base-cost.xml', { params: { names: names } })
                .then(function (response) {
                    var dom = parseXml(response.data);
                    var costs = dom.getElementsByTagName('job-base-cost');
                    for (var i = 0; i < costs.length; i++) {
                        var cost = costs[i];
                        var name = cost.getAttribute("name").replace(" Blueprint", "");
                        self.bpcList[name].JobCost = parseFloat(cost.innerHTML)
                            * self.stationActivities["Manufacturing"]
                            * self.bpcList[name].Qty;
                    }
                    
                });
        }

        function calculatePricing() {
            var items = [];
            for (var matName in self.materialList) {
                if (!self.materialList.hasOwnProperty(matName)) continue;

                var mat = self.materialList[matName];

                items.push({
                    TypeId: mat.TypeId,
                    Qty: mat.Qty
                });
            }

            $http.post('/Calculator/CalculatePricing', { params: { items: items } })
                .then(function (response) {
                    return response.data;
                });
        };

        function summarizeMaterials(material) {

            for (var j = 0; j < material.Materials.length; j++) {
                var mat = material.Materials[j];
                var matName = mat.TypeName;

                var list = mat.BuildComponents ? self.bpcList : self.materialList;

                if (!list[matName]) {
                    list[matName] = {
                        TypeId: mat.TypeId,
                        TypeName: mat.TypeName,
                        Volume: mat.Volume,
                        Qty: 0
                    };
                }

                list[matName].Qty += mat.ReducedQty;

                if (mat.BuildComponents) {
                    summarizeMaterials(mat);
                }
            }
        }

        function addBlueprint(typeId) {
            if (!typeId) return;

            var bpDetails = getBlueprint(typeId);

            bpDetails.then(function (d) {
                refreshMaterials(d);
                self.selectedBlueprints.push(d);
            });
        }

        function printTabs(tabs) {
            return "&nbsp;&nbsp;".repeat(tabs*1);
        }

        function findBlueprints(query) {
            return $http.get('/Calculator/GetBlueprints', { params: { prefix: query } })
                .then(function (response) {
                    return response.data;
                });
        }

        function findSystems(query) {
            return $http.get('/Calculator/GetSystems', { params: { prefix: query } })
                .then(function(response) {
                    return response.data;
                });
        }

        function getBlueprint(typeId) {
            return $http.get('/Calculator/GetBlueprintDetails', { params: { typeId: typeId } })
                .then(function(response) {
                    return response.data;
                });
        }

    }
})();