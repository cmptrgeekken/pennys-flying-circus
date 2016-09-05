<?php $title="Dragonfly - Get Started" ; $description="All what you need to know about how to start with Dragonfly theme." ; include( "inc/header.php"); ?>


<!-- Navigation -->
<?php include( "inc/navbar.php"); ?>


<div class="section-md bg-grey-4">
    <div class="container">
        <h2 class="text-uppercase m-no-all">Get Started</h2>
    </div>
</div>
<div class="container section-md">

    <?php include( "inc/sub-nav.php") ?>

    <h3><span class="blue-i bg-info">1</span>How To Start</h3>
    <div class="space-md"></div>
    <ol class="text-block-v1 info-list">
        <li>After unzip the purchased file, you can <strong>choose HTML or PHP version</strong> of the Dragonfly. If you choose PHP version then you will need to install PHP localhost (to customize of the template in your computer). <a href="php-tutorial.php#here">Tutorial how to install PHP localhost.</a> HTML version doesn't need any installation.
        </li>
        <li><strong>LESS Preprocessor</strong> - We recommend to customize Dragonfly right in this folder: assets/less/. Find the "variables.less" file and change for example one variable of color for whole template. Main file of all the LESS files called "main.less". All files are imported to this one main file. Also you can use some theme (structure of all themes are very similar to the "main.less", but every theme has difference variable of primary color). You can connect the main LESS file at the head of a page or you can compile it and then use as normal CSS file.<li>
        <li>Look at the <a href="elements.php#here">Elements page</a>, where you will find blocks of code. <strong>Shortcodes</strong> from dragonfly.css (dragonfly.css is generated from LESS files in the folder: assets/less/...).</li>
        <li>Read please the <a href="license-and-credits.php#here">license</a> and look at the <a href="license-and-credits.php#here">credits</a>.</li>
        <li>Give me know if you will find some issues, or if you have some ideas. On this email address: <a href="mailto:influence.bootstrap@gmail.com">influence.bootstrap@gmail.com</a>
        </li>
    </ol>

    <hr class="hr">

    <h3><span class="blue-i bg-info">2</span>Structure of Files</h3>
    <div class="space-md"></div>
    <ul class="list-unstyled text-block-v1">
        <li>
            <h4 class="text-info"><strong>Dragonfly.css</strong></h4>
        </li>
        <strong>This file is generated from LESS files in the folder: assets/less/</strong>.
        <p>List of the main category in the dragonfly.css file.</p>
        <ol>
            <li><strong>Basic declaration</strong>
            </li>
            <li><strong>Media Queries</strong>
            </li>
            <li><strong>Typography</strong> - Headings, Body, Lists, Links, Colors</li>
            <li><strong>Forms</strong> - Form with Icon, Transparent Form, Sign Up/In Pages</li>
            <li><strong>Buttons</strong> - transparent buttons, extra large button, total transparent btn</li>
            <li><strong>Images</strong> - max width 450px and 800px, max height 450px</li>
            <li><strong>Helper Classes</strong> - spaces, hr, section, filling-section, small container</li>
            <li><strong>Background</strong> - Background Color, Background Filter, Background Images</li>
            <li><strong>Jumbotron / Header</strong> - Transparent Jumbotron</li>
            <li><strong>Icons</strong> - Circle icons, Square icons, Colors of Icons</li>
            <li><strong>Icons Effects</strong> - hovicon and few beautiful animations</li>
            <li><strong>Icons Cover</strong>
            </li>
            <li><strong>Content Boxes</strong> - Large Square, Right and Center Float Box</li>
            <li><strong>Hover Content Boxes</strong> - Rotate (to the axis Y) Hover Effect, Slide from top and from bottom and more</li>
            <li><strong>Thumbnails</strong> - News Thumbnail</li>
            <li><strong>Navs</strong> - large tabs with icon, Full Width tabs, Inline Tabs, Filter Tabs, Filter Menu</li>
            <li><strong>Collapse</strong> - accordion (using on the Support page)</li>
            <li><strong>Navbar</strong> - Navbar Default (only dropdown-menu - rest of default navbar is in bootstrap.css ), transparent navbar</li>
            <li><strong>Pagition</strong> - Pagition (circle)</li>
            <li><strong>Animations</strong> - easeUp, easePulse</li>
            <li><strong>Small Components</strong> - 404 Page, Testimonial, Alerts, Clients, Knobs, Google Maps, Back To Top, Slideshow - Macbook Pro frame</li>
            <li><strong>Side Menu</strong>
            </li>
            <li><strong>Footer</strong>
            </li>
            <li><strong>Pricing Tables</strong> - 3 types</li>
            <li><strong>Blog Page</strong> - categories, tags, comments</li>
        </ol>
        <div class="space"></div>
        <li>
            <h4 class="text-info"><strong>Scripts.js</strong></h4>
        </li>
        <ol>
            <li><strong>Separate scripts</strong>
            </li>
            <ul>
                <li>Back to top button</li>
                <li>Smooth scroll - from href to id</li>
                <li>Remove conflict with loading animations</li>
                <li>Sidebar</li>
                <li>Smooth scrolling</li>
                <li>Style Switcher</li>
            </ul>
            <div class="space-sm"></div>
            <li><strong>Custom settings for plugins</strong>
            </li>
            <ul>
                <li>Loading animations - wow.js</li>
                <li>Filterable portfolio - jquery.mixitup.js</li>
                <li>Slideshow - slippry.js</li>
                <li>Make every elements sticky, just set a ID - jquery.sticky.js</li>
                <li>Knobs - jquery.knob.js</li>
            </ul>
        </ol>
        <div class="space"></div>
        <li>
            <h4 class="text-info"><strong>Scripts inside the page</strong></h4>
        </li>
        <ol>
            <li>About Us II (about-us-v2.php) and About Us III (about-us-v3.php) - <strong>Chart.js</strong>
            </li>
            <li>Contact (contact.php) and Home Page II (index-2.php) - <strong>Google Maps - initmap.min.js</strong>
            </li>
        </ol>
    </ul>

    <hr class="hr">

    <h3><span class="blue-i bg-info">3</span>Contact Form (AJAX + PHP)</h3>
    <div class="space-md"></div>
    <ol class="text-block-v1">
        <p>Contact Form consists of three parts - <code>mailer.php</code> in the root folder, <code>contact-form.js</code> in the js folder (js/contact-form.js) and third part is in contact.php or index-2.php.</p>
        <li>You see below Html part of contact form.</li>
        <div class="space-sm"></div>
        <pre class="brush: html">
                <!-- Contact Form -->
                <div id="form-messages"></div>
                <form class="form-horizontal" role="form" id="ajax-contact" method="post" action="mailer.php">
                    <div class="form-group icon">
                        <label for="name" class="col-sm-3 control-label">Full name</label>
                        <div class="col-sm-9 ">
                            <div class="control">
                                <input type="text" class="form-control" id="name" placeholder="Full name" name="name" required>
                                <i class="fa fa-user"></i>
                            </div>
                        </div>
                    </div>
                    <div class="form-group icon">
                        <label for="email" class="col-sm-3 control-label">Email</label>
                        <div class="col-sm-9 ">
                            <div class="control">
                                <input type="email" class="form-control" id="email" placeholder="Enter email" name="email" required>
                                <i class="fa fa-envelope"></i>
                            </div>
                        </div>
                    </div>
                    <div class="form-group icon">
                        <label for="Message" class="col-sm-3 control-label">Message</label>
                        <div class="col-sm-9 ">
                            <div class="control">
                                <textarea class="form-control" rows="8" id="Message" placeholder="Message" name="message" required></textarea>
                                <i class="fa fa-comment"></i>
                            </div>
                        </div>
                    </div>

                    <div class="form-group icon">
                        <div class="col-sm-offset-3 col-sm-9">
                            <button type="submit" class="btn btn-primary">
                                <i class="fa fa-paper-plane-o"></i>Send Message</button>
                        </div>
                    </div>
                </form>
        </pre>
        <div class="space"></div>
        <li>Then you will need to copy <code>mailer.php</code> from the root folder, and add line of code which you see below.</li>
        <div class="space-sm"></div>
        <pre class="brush: html">
            <!-- Contact From -->
            <script src="contact-form.js"></script>
        </pre>
    </ol>
</div>

<!--  Footer  -->
<?php include( "inc/footer.php"); ?>


</body>

</html>