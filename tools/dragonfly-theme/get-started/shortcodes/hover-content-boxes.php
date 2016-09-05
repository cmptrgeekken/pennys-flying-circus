<div class="page-header">
    <h2 class="text-uppercase">Hover Content Boxes</h2>
</div>

<div class="space"></div>
<span id="rotate-hover-effect" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title md-title">Rotate Hover Effect</h3>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-heading">
        First you need create tag with class <code>.hover-content</code>, then inside create tag with class <code>.visible-part</code> and <code>.hidden-part</code>. See it below.
    </div>
    <div class="panel-body">
        <div class="row section-sm">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-body text-center">
                        <div class="hover-content">
                            <div class="visible-part">
                                <h4 class="type">Basic</h4>
                                <h3 class="price text-primary">$5</h3>
                                <small class="text-grey month">per month</small>
                                <h5 class="text-primary details">View Details</h5>
                            </div>
                            <div class="hidden-part">
                                <h4 class="type">Details</h4>
                                <ul class="list-unstyled info-list md-list">
                                    <li><span class="text-primary">5Gb</span> Storage</li>
                                    <li><span class="text-primary">1</span> Email account</li>
                                    <li><span class="text-primary">2</span> Hosted domains</li>
                                    <li><span class="text-primary">24/7</span> Email support</li>
                                </ul>
                                <a href="#"><h5 class="text-primary details">Start Trial</h5></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-body text-center">
                        <div class="hover-content">
                            <div class="visible-part">
                                <h4 class="type">Basic</h4>
                                <h3 class="price text-primary">$10</h3>
                                <small class="text-grey month">per month</small>
                                <h5 class="text-primary details">View Details</h5>
                            </div>
                            <div class="hidden-part">
                                <h4 class="type">Details</h4>
                                <ul class="list-unstyled info-list md-list">
                                    <li><span class="text-primary">5Gb</span> Storage</li>
                                    <li><span class="text-primary">1</span> Email account</li>
                                    <li><span class="text-primary">2</span> Hosted domains</li>
                                    <li><span class="text-primary">24/7</span> Email support</li>
                                </ul>
                                <a href="#"><h5 class="text-primary details">Start Trial</h5></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
            <div class="hover-content">
                <div class="visible-part">
                    <!--Will be hidden after hover on the hover-content-->
                </div>
                <div class="hidden-part">
                    <!-- Will be visible after hover on the hover-content-->
                </div>
            </div>
        </pre>
    </div>
</div>

<div class="space"></div>
<span id="slide-to-middle" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title md-title">Slide to middle</h3>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-heading">
        First you need create tag with class <code>.hover-content</code>, then inside create tag with class <code>.top-part</code> and <code>.bottom-part</code>. See it below.
        <br>
        <em>Notice that <code>.top-part</code> and <code>.bottom-part</code> have class <code>.hidden-xs</code>, that means this effect will not to display on screen less than 768px - mobile devices.</em>
    </div>
    <div class="panel-body">
        <div class="row section-sm">
            <div class="col-md-6">
                <a href="#" title="View portfolio item">
                    <div class="hover-content">
                        <img src="../assets/img/minimal-wireframe-assets.jpg" class="img-responsive" alt="Websites Layout">
                        <div class="top-part hidden-xs">
                            <i class="fa fa-eye"></i>
                        </div>
                        <div class="bottom-part hidden-xs">
                            <h3>Title</h3>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-md-6">
                <a href="#" title="View portfolio item">
                    <div class="hover-content">
                        <img src="../assets/img/minimal-wireframe-assets.jpg" class="img-responsive" alt="Websites Layout">
                        <div class="top-part hidden-xs">
                            <i class="fa fa-eye"></i>
                        </div>
                        <div class="bottom-part hidden-xs">
                            <h3>Title</h3>
                        </div>
                    </div>
                </a>
            </div>
        </div>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
                <a href="#">
                    <div class="hover-content">
                        <img class="img-responsive" alt="...">
                        <div class="top-part hidden-xs">
                            <i class="fa fa-eye"></i>
                        </div>
                        <div class="bottom-part hidden-xs">
                            <h3>...</h3>
                        </div>
                    </div>
                </a>
        </pre>
    </div>
</div>

<div class="space"></div>
<span id="profile-effects" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title md-title">Profile Effects</h3>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-heading">
        First you need create tag with class <code>.profile</code>, then inside <code>.hover-content</code>, inside add image, then create tag with two classes <code>.content-open</code> and <code>.content-center</code>. See it below.
    </div>
    <div class="panel-body">
        <div class="row section-sm">
            <div class="col-sm-6">
                <div class="profile">
                    <div class="hover-content">
                        <img class="img-responsive" alt="Our team" src="../assets/img/faces/face-25.jpg">
                        <div class="content-open content-center">
                            <ul class="circle-icons text-center icons-list">
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-google-plus"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-twitter"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-linkedin"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-facebook"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="profile">
                    <div class="hover-content">
                        <img class="img-responsive" alt="Our team" src="../assets/img/faces/face-22.jpg">
                        <div class="content-open content-center">
                            <ul class="circle-icons text-center icons-list">
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-google-plus"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-twitter"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-linkedin"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-facebook"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
                <div class="profile">
                    <div class="hover-content">
                        <img class="img-responsive" alt="..." >
                        <div class="content-open content-center">
                            <ul class="circle-icons text-center icons-list">
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-google-plus"></i>
                                    </a>
                                </li>
                                ....
                            </ul>
                        </div>
                    </div>
                </div>
        </pre>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-heading">
        First you need create tag with class <code>.profile-circle</code>, then inside <code>.hover-content</code>, inside add image, then create tag with two classes <code>.content-open</code> and <code>.content-center</code>. See it below.
    </div>
    <div class="panel-body">
        <div class="row section-sm">
            <div class="col-sm-6">
                <div class="profile-circle">
                    <div class="hover-content ">
                        <img class="img-responsive" alt="Our team" src="../assets/img/faces/face-5.jpg">
                        <div class="content-circle content-center">
                            <ul class="circle-icons icons-list">
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-google-plus"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-twitter"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-linkedin"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-facebook"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <h3>Stephanie Morrison
                            <small>Designer</small>
                        </h3>
                    <p>Cras vel urna iaculis orci pulvinar convallis ut eget nunc. Integer a mi ante. Sed ac urna commodo, volutpat justo a, mollis mi.</p>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="profile-circle">
                    <div class="hover-content ">
                        <img class="img-responsive" alt="Our team" src="../assets/img/faces/face-9.jpg">
                        <div class="content-circle content-center">
                            <ul class="circle-icons icons-list">
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-google-plus"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-twitter"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-linkedin"></i>
                                    </a>
                                </li>
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-facebook"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <h3>Stephanie Morrison
                            <small>Designer</small>
                        </h3>
                    <p>Cras vel urna iaculis orci pulvinar convallis ut eget nunc. Integer a mi ante. Sed ac urna commodo, volutpat justo a, mollis mi.</p>
                </div>
            </div>
        </div>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
                <div class="profile-circle">
                    <div class="hover-content ">
                        <img class="img-responsive" alt="..." >
                        <div class="content-circle content-center">
                            <ul class="circle-icons icons-list">
                                <li>
                                    <a href="#" title="Follow us">
                                        <i class="fa fa-google-plus"></i>
                                    </a>
                                </li>
                                ...
                            </ul>
                        </div>
                    </div>
                </div>
        </pre>
    </div>
</div>

<div class="space"></div>
<span id="slide-from-corners" class="nID"></span>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title md-title">Slide from Corners</h3>
    </div>
</div>

<div class="panel panel-default">
    <div class="panel-heading">
        First you need create tag with class <code>.hover-content</code>, then inside create three tag with class <code>.part-a</code> - datum of publishing, <code>.part-b</code> - basic info about a post and <code>.part-c</code> - for author of a post (small photo). See it below.
    </div>
    <div class="panel-body">
        <div class="row section-sm">
            <div class="col-sm-6">
                <div class="hover-content">
                    <div class="part-a">
                        <h3>18</h3>
                        <h3>April</h3>
                    </div>
                    <div class="part-c">
                        <img class="img-responsive" src="../assets/img/faces/face-25.jpg" alt="Blog Post Author" title="Nicole Perry">
                    </div>
                    <div class="part-b">
                        <ul>
                            <li>
                                <i class="fa fa-user fa-fw"></i>
                                <a href="#" title="View Profile">Nicole Perry</a>
                            </li>
                            <li>
                                <i class="fa fa-clock-o fa-fw"></i>18 April 2014
                            </li>
                            <li>
                                <i class="fa fa-comments fa-fw"></i>
                                <a href="blog-item.php" title="Read Comments">27 Comments</a>
                            </li>
                            <li>
                                <i class="fa fa-tags fa-fw"></i>
                                <a href="#">Nature,</a>
                                <a href="#">Photo,</a>
                                <a href="#">Sea</a>

                            </li>
                        </ul>
                    </div>
                    <img class="img-responsive" alt="Blog Image" src="../assets/img/768w/0c76b.JPG">
                </div>
            </div>
            <div class="col-sm-6">
                <div class="hover-content">
                    <div class="part-a">
                        <h3>18</h3>
                        <h3>April</h3>
                    </div>
                    <div class="part-c">
                        <img class="img-responsive" src="../assets/img/faces/face-25.jpg" alt="Blog Post Author" title="Nicole Perry">
                    </div>
                    <div class="part-b">
                        <ul>
                            <li>
                                <i class="fa fa-user fa-fw"></i>
                                <a href="#" title="View Profile">Nicole Perry</a>
                            </li>
                            <li>
                                <i class="fa fa-clock-o fa-fw"></i>18 April 2014
                            </li>
                            <li>
                                <i class="fa fa-comments fa-fw"></i>
                                <a href="blog-item.php" title="Read Comments">27 Comments</a>
                            </li>
                            <li>
                                <i class="fa fa-tags fa-fw"></i>
                                <a href="#">Nature,</a>
                                <a href="#">Photo,</a>
                                <a href="#">Sea</a>

                            </li>
                        </ul>
                    </div>
                    <img class="img-responsive" alt="Blog Image" src="../assets/img/768w/0c76b.JPG">
                </div>

            </div>

        </div>
    </div>
    <div class="code-footer">
        <pre class="brush: html">
                <div class="hover-content">
                    <!-- Part A-->
                    <div class="part-a">
                        <h3>18</h3>
                        <h3>April</h3>
                    </div>
                    <!-- Part C-->
                    <div class="part-c">
                        <img class="img-responsive"  alt="...">
                    </div>
                    <!-- Part B-->
                    <div class="part-b">
                        <ul>
                            <li>
                                <i class="fa fa-user fa-fw"></i>
                                <a href="#" title="View Profile">author</a>
                            </li>
                            <li>
                                <i class="fa fa-clock-o fa-fw"></i>datum
                            </li>
                            <li>
                                <i class="fa fa-comments fa-fw"></i>
                                <a href="#">27 Comments</a>
                            </li>
                            <li>
                                <i class="fa fa-tags fa-fw"></i>
                                <a href="#">Nature,</a>
                                <a href="#">Photo,</a>
                                <a href="#">Sea</a>
                            </li>
                        </ul>
                    </div>
                    <img class="img-responsive" alt="..." >
                </div>
        </pre>
    </div>
</div>