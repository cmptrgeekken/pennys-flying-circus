<?php $title="Dragonfly - Elements" ; $description="" ; include( "inc/header.php"); ?>


<!-- Navigation -->
<?php include( "inc/navbar.php"); ?>


<div class="section-md bg-grey-4">
    <div class="container">
        <h2 class="text-uppercase m-no-all">Elements</h2>
    </div>
</div>

<div class="container section">

    <?php include( "inc/sub-nav.php") ?>

    <div class="row">
        <div class="col-sm-3">
            <ul class="list-group sticker-nav nav-menu" data-parent="#sidebar">

                <li class="list-group-item">
                    <a data-toggle="collapse" data-parent="#sidebar" href="#collapse-typography">Typography</a>
                    <ul id="collapse-typography" class="collapse">
                        <li>
                            <a class="scroll" href="#grid">Grid Layout</a>
                        </li>
                        <li>
                            <a class="scroll" href="#headings">Headings</a>
                        </li>
                        <li>
                            <a class="scroll" href="#body-text">Body Text</a>
                        </li>
                        <li>
                            <a class="scroll" href="#inline-text">Inline text elements</a>
                        </li>
                        <li>
                            <a class="scroll" href="#alignment-classes">Alignment classes</a>
                        </li>
                        <li>
                            <a class="scroll" href="#transformation-classes">Transformation classes</a>
                        </li>
                        <li>
                            <a class="scroll" href="#abbreviations">Abbreviations</a>
                        </li>
                        <li>
                            <a class="scroll" href="#addresses">Addresses</a>
                        </li>
                        <li>
                            <a class="scroll" href="#blockquotes">Blockquotes</a>
                        </li>
                        <li>
                            <a class="scroll" href="#lists">Lists</a>
                        </li>
                    </ul>
                </li>
                <li class="list-group-item">
                    <a class="scroll" href="#forms">Forms</a>
                </li>

                <li class="list-group-item">
                    <a class="scroll" href="#buttons">Buttons</a>
                </li>
                <li class="list-group-item">
                    <a data-toggle="collapse" data-parent="#sidebar" href="#helper-classes">Helper Classes</a>
                    <ul id="helper-classes" class="collapse">
                        <li>
                            <a class="scroll" href="#spaces">Spaces</a>
                        </li>
                        <li>
                            <a class="scroll" href="#sections">Sections</a>
                        </li>
                        <li>
                            <a class="scroll" href="#center-block">Center Block</a>
                        </li>
                        <li>
                            <a class="scroll" href="#margins">Margins</a>
                        </li>
                        <li>
                            <a class="scroll" href="#paddings">Paddings</a>
                        </li>
                        <li>
                            <a class="scroll" href="#colors">Colors</a>
                        </li>
                        <li>
                            <a class="scroll" href="#bg-filter">Filter of Background</a>
                        </li>
                    </ul>
                </li>

                <li class="list-group-item">
                    <a data-toggle="collapse" data-parent="#sidebar" href="#icons">Icons</a>
                    <ul id="icons" class="collapse">
                        <li>
                            <a class="scroll" href="#general-icons">General Icons</a>
                        </li>
                        <li>
                            <a class="scroll" href="#icons-effects">Icons Effects</a>
                        </li>
                        <li>
                            <a class="scroll" href="#icons-cover">Icons Cover</a>
                        </li>
                    </ul>
                </li>
                <li class="list-group-item">
                    <a data-toggle="collapse" data-parent="#sidebar" href="#content-boxes">Content Boxes</a>
                    <ul id="content-boxes" class="collapse">
                        <li>
                            <a class="scroll" href="#float">Float Box</a>
                        </li>
                        <li>
                            <a class="scroll" href="#square">Square Box</a>
                        </li>
                    </ul>
                </li>
                <li class="list-group-item">
                    <a data-toggle="collapse" data-parent="#sidebar" href="#hover-content-boxes">Hover Content Boxes</a>
                    <ul id="hover-content-boxes" class="collapse">
                        <li>
                            <a class="scroll" href="#rotate-hover-effect">Rotate Hover Effect</a>
                        </li>
                        <li>
                            <a class="scroll" href="#slide-to-middle">Slide to Middle</a>
                        </li>
                        <li>
                            <a class="scroll" href="#profile-effects">Profile Effects</a>
                        </li>
                        <li>
                            <a class="scroll" href="#slide-from-corners">Slide from Corners</a>
                        </li>
                    </ul>
                </li>
                <li class="list-group-item">
                    <a data-toggle="collapse" data-parent="#sidebar" href="#navs">Navs</a>
                    <ul id="navs" class="collapse">
                        <li>
                            <a class="scroll" href="#large-tabs">Large Tabs</a>
                        </li>
                        <li>
                            <a class="scroll" href="#inline-tabs">Inline Tabs</a>
                        </li>
                        <li>
                            <a class="scroll" href="#fw-tabs">Full Width Tabs</a>
                        </li>
                        <li>
                            <a class="scroll" href="#filter-tabs">Filter Tabs</a>
                        </li>
                        <li>
                            <a class="scroll" href="#filter-menu">Filter Menu</a>
                        </li>
                    </ul>
                </li>
                <li class="list-group-item">
                    <a class="scroll" href="#collapse">Collapse</a>
                </li>
            </ul>
        </div>

        <div class="col-md-9">
            <div class="alert alert-info">Complete official documentation for Bootstrap framework you can find <a href="http://getbootstrap.com/css/" target="_blank">here</a>.</a>
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
            </div>
            <?php include( "shortcodes/typography.php"); ?>
            <?php include( "shortcodes/forms.php"); ?>
            <?php include( "shortcodes/buttons.php"); ?>
            <?php include( "shortcodes/helper-classes.php"); ?>
            <?php include( "shortcodes/icons.php"); ?>
            <?php include( "shortcodes/content-boxes.php"); ?>
            <?php include( "shortcodes/hover-content-boxes.php"); ?>
            <?php include( "shortcodes/navs.php"); ?>
            <?php include( "shortcodes/collapse.php"); ?>
        </div>
    </div>

</div>


<!--  Footer  -->
<?php include( "inc/footer.php"); ?>

</body>

</html>