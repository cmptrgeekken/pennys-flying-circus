<?php $title="Dragonfly - Changelog" ; $description="Full upgrade list of the Dragonfly bootstrap theme." ; include( "inc/header.php"); ?>


<!-- Navigation -->
<?php include( "inc/navbar.php"); ?>


<div class="section-md bg-grey-4">
    <div class="container">
        <h2 class="text-uppercase m-no-all">Changelog</h2>
    </div>
</div>


<div class="container section">

    <div class="panel-group" id="changes">
        
        <div class="panel panel-default">
            <a data-toggle="collapse" data-parent="#changes" href="#c3">
                <div class="panel-heading">
                    <h4 class="panel-title text-primary">Version 1.5 <small>September 6, 2014</small></h4>
                </div>
            </a>
            <div id="c3" class="panel-collapse collapse in">
                <div class="panel-body">
                    <h4 class="text-info">Extensive changes</h4>
                    <ul class="i-primary info-list md-list">
                        <li><i class="fa fa-check"></i><span class="label label-default">NEW</span> It was added HTML version of Dragonfly - now you can choose from <strong>2 version PHP and HTML</strong>.</li>
                        <li><i class="fa fa-check"></i><span class="label label-default">NEW</span> <strong>Complete LESS</strong> files for whole template.</li>
                        <li><i class="fa fa-check"></i><span class="label label-default">NEW</span> It was added the <strong>Style Switcher</strong> - 5 beatiful colors, 3 themes of navbar (light, dark and transparent) + you can set navbar to fix to top (animation of background when you scroll down) or normal navbar with relative position.</li>
                        <li><i class="fa fa-check"></i><span class="label label-default">UPGRADE</span> We improved design of the navbar, header and we made much more smaller improvements in across the template.</li>
                        <li><i class="fa fa-check"></i><span class="label label-default">UPGRADE</span> The sidebar was completely changed. Click on the icon at the navbar to see the change.</li>
                        
                        <li><i class="fa fa-check"></i><span class="label label-default">FIX</span> Fix the problem with smooth scrolling in IE 10.</li>
                    </ul>

                    <div class="space-sm"></div>

                    <h4 class="text-muted">Small changes</h4>
                    <ul class="i-muted info-list md-list">
                        <li><i class="fa fa-check"></i>Add classes <code>.bg-center</code>, <code>.bg-cover</code>, <code>.bg-fixed</code> for easier customization. (If you are already using Dragonfly theme, you will need to add these classes)</li>
                        <li><i class="fa fa-check"></i>For faster loading now we are using CDN for most of plugins.</li>
                        <li><i class="fa fa-check"></i>Also we included PSD sources for you for next usage. (at the folder assets/psd/...)</li>
                        <li><i class="fa fa-check"></i>All pluging using on this template you can find at the folder: assets/plugins/...</li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <a data-toggle="collapse" data-parent="#changes" href="#c3">
                <div class="panel-heading">
                    <h4 class="panel-title text-primary">Version 1.4 <small>August 4, 2014</small></h4>
                </div>
            </a>
            <div id="c3" class="panel-collapse collapse in">
                <div class="panel-body">
                    <h4 class="text-info">Extensive changes</h4>
                    <ul class="i-primary info-list md-list">
                        <li><i class="fa fa-check"></i><strong>Working Contact form</strong> - based on PHP and AJAX</li>
                        <li><i class="fa fa-check"></i>Smooth scrolling - new plugin</li>
                        <li><i class="fa fa-check"></i>New Section of page - Get Started. It includes <strong>Documentation, Changelog, Licence & Credits</strong>. You will find tutorial how to install PHP server (localhost), basic informations how to started - structure of files and more and also the Elements page where you will find blocks of code from Dragonfly theme</li>
                        <li><i class="fa fa-check"></i>New plugin for sidebar - using in the get started section</li>
                    </ul>

                    <div class="space-sm"></div>

                    <h4 class="text-muted">Small changes</h4>
                    <ul class="i-muted info-list md-list">
                        <li><i class="fa fa-check"></i>Fixed a few bugs
                        </li>
                        <li><i class="fa fa-check"></i>Better optimization for mobile devices</li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <a data-toggle="collapse" data-parent="#changes" href="#c2">
                <div class="panel-heading">
                    <h4 class="panel-title text-primary">Version 1.3 <small>July 24, 2014</small></h4>
                </div>
            </a>
            <div id="c2" class="panel-collapse collapse">
                <div class="panel-body">
                    <h4 class="text-info">Extensive changes</h4>
                    <ul class="i-primary info-list md-list">
                        <li><i class="fa fa-check"></i>New Starting animations - <code>.fromPocket</code>  <code>.pulseIn</code>  <code>.openIn</code>  <code>.switchOnTv</code> and <code>.openSection</code>
                        </li>
                        <li><i class="fa fa-check"></i>New simple portfolio page with clean and minimalistic design - <a href="portfolio-v3.php">Link</a> 
                        </li>
                        <li><i class="fa fa-check"></i>Now Dragonfly uses PHP for header and footer
                        </li>
                        <li><i class="fa fa-check"></i>Deep reconstruction of all links and directories</li>
                    </ul>

                    <div class="space-sm"></div>

                    <h4 class="text-muted">Small changes</h4>
                    <ul class="i-muted info-list md-list">
                        <li><i class="fa fa-check"></i>Pricing Tables - changed for more universal usage of the code, small changes in design - <a href="pricing-tables.php">Link</a>
                        </li>
                        <li><i class="fa fa-check"></i>Redesign <code>.lg-tabs</code> - look at the new design <a href="services-v3.php">here</a>
                        </li>
                        <li><i class="fa fa-check"></i>Chect out the Collapse in dragonfly.css - changed for more universal usage of the code</li>
                        <li><i class="fa fa-check"></i>New Class - <code>.section-sm</code> (padding top and bottom is 20px)</li>
                        <li><i class="fa fa-check"></i><code>.alert .close</code> - white color, no text-shadow</li>
                        <li><i class="fa fa-check"></i>The profile-circle has not any bottom margin for over 768px - <code>.team-grid .row:not(:last-child) .profile-circle</code> 
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <a data-toggle="collapse" data-parent="#changes" href="#c1">
                <div class="panel-heading">
                    <h4 class="panel-title text-primary">Version 1.2 <small>July 12, 2014</small></h4>
                </div>
            </a>
            <div id="c1" class="panel-collapse collapse">
                <div class="panel-body">
                    <ul class="i-primary info-list md-list">
                        <li><i class="fa fa-check"></i>Update to <strong>Bootstrap v3.2</strong>
                        </li>
                        <li><i class="fa fa-check"></i>New Home page - Option 2</li>
                        <li><i class="fa fa-check"></i>Better organisation of styles - dragonfly.css</li>
                        <li><i class="fa fa-check"></i>Change Background Image on Home page - Option 1</li>
                        <li><i class="fa fa-check"></i>Move Contact Page in the Pages folder</li>
                        <li><i class="fa fa-check"></i>New Background - faces.png</li>
                    </ul>
                </div>
            </div>
        </div>

    </div>

</div>

<!--  Footer  -->
<?php include( "inc/footer.php"); ?>


</body>

</html>