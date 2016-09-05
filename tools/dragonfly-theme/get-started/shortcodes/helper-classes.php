<span id="helper-classes" class="nID"></span>
<div class="page-header">
    <h2 class="text-uppercase">Helper Classes</h2>
</div>
<div class="space"></div>
<span id="spaces" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Spaces</h3>
    </div>
    <div class="panel-body ">
        <code>.space-sm</code>
        <code>.space-md</code>
        <code>.space</code>
        <code>.space-lg</code>
    </div>
    <div class="code-footer">
        <pre class="brush: css">
        .space-sm {
            padding-top: 15px;
        }
        .space-md {
            padding-top: 20px;
        }
        .space {
            padding-top: 30px;
        }
        .space-lg {
            padding-top: 50px;
        }
        </pre>
    </div>
</div>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Special line</h3>
    </div>
    <div class="panel-body ">
        <p>Add to hr tag class <code>.hr</code>
        </p>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
        <!-- HTML file -->
        
            <hr class="hr">
        </pre>
        <div class="space-sm"></div>
        <pre class="brush: css">
        /* CSS file */
           
            .hr {
               margin-top: 40px;
               margin-bottom: 40px;
            }
        </pre>
    </div>
</div>

<span id="sections" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Sections</h3>
    </div>
    <div class="panel-body ">
        <p>Make you page clear and comfortable to read with <code>.section</code>
        </p>
    </div>
    <div class="code-footer">
        <pre class="brush: css">
            @media (min-width: 768px) {
                .section-sm {
                    padding: 20px 0;
                }
                .section-md {
                    padding: 30px 0;
                }
                .section {
                    padding: 50px 0;
                }
                .section-lg {
                    padding: 80px 0;
                }
            }
            @media (max-width: 768px) {
                .section-sm {
                    padding: 15px 0;
                }
                .section-md {
                    padding: 20px 0;
                }
                .section {
                    padding: 30px 0;
                }
                .section-lg {
                    padding: 50px 0;
                }
            }
        </pre>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Filling Section</h3>
    </div>
    <div class="panel-body ">
        <p>Minimal height of this section is 350px - section only for background image.</p>
    </div>
    <div class="code-footer">
        <pre class="brush: css">
         .filling-section {
            min-height: 350px;
            position: relative;
        }
        </pre>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Small Container</h3>
    </div>
    <div class="panel-body ">
        <p>Smaller container with width maximally 800px - <code>.container-sm</code>
        </p>
    </div>
    <div class="code-footer">
        <pre class="brush: css">
            .container-sm {
                max-width: 800px;
                margin: 0 auto;
                padding-left: 15px;
                padding-right: 15px;
            }
        </pre>
    </div>
</div>
<span id="center-block" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Center block</h3>
    </div>
    <div class="panel-body ">
        <p>Center every element with <code>.v-center</code> class for vertical center and <code>.h-center</code> class for horizontal center. You need to set <code>position: relative;</code> to parent element.</p>
    </div>
    <div class="code-footer">
        <pre class="brush: css">
        .h-center,
        .v-center {
            position: absolute;
            top: 50%;
        }
        .v-center {
            -webkit-transform: translate(0, -50%);
            -ms-transform: translate(0, -50%);
            transform: translate(0, -50%);
        }
        .h-center {
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }
        </pre>
    </div>
</div>
<span id="margins" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Margins</h3>
    </div>
    <div class="panel-body ">
        <p>You can use <code>.m-no-all</code> for no margin.</p>
        <p>Or no bottom margin <code>.m-no-bottom</code>.</p>
        <p>Or no top margin <code>.m-no-top</code>.</p>
    </div>
    <div class="code-footer">
        <pre class="brush: css">
            .m-no-all {
                margin: 0;
            }
            .m-no-bottom {
                margin-bottom: 0;
            }
            .m-no-top {
                margin-top: 0;
            }
            .m-no-left {
                margin-left: 0;
            }
            .m-no-right {
                margin-right: 0;
            }
            .m-10-top {
                margin-top: 10px;
            }
        </pre>
    </div>
</div>

<span id="paddings" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Paddings</h3>
    </div>
    <div class="panel-body ">
        <p>You can use <code>.p-no-left</code> for no left padding, as you see below.</p>
    </div>
    <div class="code-footer">
        <pre class="brush: css">
            .p-no-all {
                padding: 0;
            }
            .p-no-bottom {
                padding-bottom: 0;
            }
            .p-no-top {
                padding-top: 0;
            }
            .p-no-left {
                padding-left: 0;
            }
            .p-no-right {
                padding-right: 0;
            }
        </pre>
    </div>
</div>

<div class="space"></div>
<span id="colors" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title md-title">Colors</h3>
    </div>
</div>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Colors for text</h3>
    </div>
    <div class="panel-body ">
        <p class="text-muted">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="text-primary">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="text-success">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="text-info">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="text-warning">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="text-danger">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
			<p class="text-muted">...</p>
			<p class="text-primary">...</p>
			<p class="text-success">...</p>
			<p class="text-info">...</p>
			<p class="text-warning">...</p>
			<p class="text-danger">...</p>
			
			<!-- Color: #fff -->
			<p class="text-white">...</p>
			
			<!-- Color: #ddd -->
			<p class="text-light">...</p>
        </pre>
    </div>
</div>


<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Colors Background</h3>
    </div>
    <div class="panel-body padding-15">
        <p class="bg-primary">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="bg-success">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="bg-info">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="bg-warning">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <p class="bg-danger">Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
        <div class="space"></div>
        <h3>Colors of Social Networks</h3>
        <div class="space-sm"></div>
        <p class="facebook"><span class="text-white">Facebook - #3b5998</span>
        </p>
        <p class="google"><span class="text-white">Google+ - #dd4b39</span>
        </p>
        <p class="twitter"><span class="text-white">Twitter - #00aced</span>
        </p>
        <p class="youtube"><span class="text-white">YouTube - #bb0000</span>
        </p>
        <p class="linkedin"><span class="text-white">Linkedin - #007bb6</span>
        </p>
        <p class="instagram"><span class="text-white">Instagram - #517fa4</span>
        </p>
        <p class="pinterest"><span class="text-white">Pinterest - #cb2027</span>
        </p>
        <p class="vine"><span class="text-white">Vine - #00bf8f</span>
        </p>
        <p class="snapchat"><span>Snapchat - #fffc00</span>
        </p>
        <p class="flickr"><span class="text-white">Flickr - #ff0084</span>
        </p>
        <p class="tumblr"><span class="text-white">Tumblr - #32506d</span>
        </p>
        <p class="vimeo"><span class="text-white">Vimeo - #aad450</span>
        </p>
        <p class="foursquare"><span class="text-white">Foursquare - #0072b1</span>
        </p>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
			<p class="bg-primary">...</p>
			<p class="bg-success">...</p>
			<p class="bg-info">...</p>
			<p class="bg-warning">...</p>
			<p class="bg-danger">...</p>
      		
       		<!-- Social Networks -->
       		<p class="facebook">...</p>
			<p class="google">...</p>
			<p class="twitter">...</p>
        </pre>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-body padding-15">
        <p class="bg-dark-1"></p>
        <p class="bg-dark"></p>
        <p class="bg-grey"></p>
        <p class="bg-grey-1"></p>
        <p class="bg-grey-2"></p>
        <p class="bg-grey-3"></p>
        <p class="bg-grey-4"></p>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
		<p class="bg-dark-1">...</p>
		<p class="bg-dark">...</p>
		<p class="bg-grey">...</p>
		<p class="bg-grey-1">...</p>
		<p class="bg-grey-2">...</p>
		<p class="bg-grey-3">...</p>
		<p class="bg-grey-4">...</p>
        </pre>
    </div>
</div>

<span id="bg-filter" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3>Filter of Background</h3>
    </div>
    <div class="panel-body padding-15">
        <div class="row">
            <div class="col-md-4">
                <div class="bg-1 bg-center bg-cover">
                    <div class="bg-filter-v2 section-lg text-center">
                        <h3 class="m-no-all">.bg-filter-v2</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="bg-1 bg-center bg-cover">
                    <div class="bg-filter section-lg text-center">
                        <h3 class="m-no-all">.bg-filter</h3>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="bg-1 bg-center bg-cover">
                    <div class="bg-filter-v1 section-lg text-center">
                        <h3 class="m-no-all">.bg-filter-v1</h3>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="code-footer">
        <pre class="brush: html">
				<!-- HTML File -->
				<div class="background-image">
					<div class="bg-filter">
						...
					</div>
				</div>
        </pre>
    </div>
    <div class="space-sm"></div>
    <div class="code-footer">
        <pre class="brush: css">
		/* CSS File */
			.bg-filter-v2 {
				background: rgba(0, 0, 0, 0.75);
				color: #fff;
			}
			.bg-filter {
				background: rgba(0, 0, 0, 0.6);
				color: #fff;
			}
			.bg-filter-v1 {
				background: rgba(0, 0, 0, 0.45);
				color: #fff;
			}
        </pre>
    </div>
</div>