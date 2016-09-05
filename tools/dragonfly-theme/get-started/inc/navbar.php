
<!-- Main Navbar -->
<div class="section-md bg-dark-1">
    <div class="container">
        <div class="clearfix">
            <div class="pull-left">
                <h2 class="text-info m-no-all"><a href="../index-2.php" title="Back To Home Page"><i class="fa fa-home text-info"></i> </a>Get Started<span class="label">Dragonfly</span></h2>
            </div>
            <div class="pull-right" id="st-trigger-effects">
                <button class="icon-bars" data-effect="st-effect-3" type="button">
                    <span class="bar"></span>
                    <span class="bar"></span>
                    <span class="bar"></span>
                </button>
            </div>
        </div>
    </div>
</div>

<!-- Submenu -->
<div class="container section-lg">
    <div class="row">
        <div class="col-sm-4">
            <a  <?php echo ($title == "Dragonfly - Get Started" ) ? "class='active'" : ""; ?> href="index.php" >
                <div class="square">
                    <i class="fa fa-tasks"></i>
                    <h2>Documentation</h2>
                    <p>Tutorial to PHP, elements from all template, how to start</p>
                </div>

            </a>
        </div>
        <div class="col-sm-4">
            <a  <?php echo ($title == "Dragonfly - Changelog" ) ? "class='active'" : ""; ?> href="changelog.php">
                <div class="square">
                    <i class="fa fa-check-square-o"></i>
                    <h2>Changelog</h2>
                    <p>Full upgrade list of the Dragonfly bootstrap theme</p>
                </div>
            </a>
        </div>
        <div class="col-sm-4">
            <a  <?php echo ($title == "Dragonfly - License & Credits" ) ? "class='active'" : ""; ?> href="license-and-credits.php">
                <div class="square">
                    <i class="fa fa-file-text"></i>
                    <h2>License &amp; Credits</h2>
                    <p>Read please the license and look at the credits</p>
                </div>
            </a>
        </div>
    </div>
</div>

<div id="here"></div>