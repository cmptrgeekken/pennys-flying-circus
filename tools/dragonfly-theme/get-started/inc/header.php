<!DOCTYPE html>
<html lang="en">

<head>
    <title>
        <?php echo $title; ?>
    </title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="<?php echo $description; ?>">
    <meta name="author" content="Jiri Cermak">

    <!--  Boostrap Framework  -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet">
    <!--  Dragonfly stylesheet -->
    <link href="../assets/css/dragonfly.min.css" rel="stylesheet">
    <!--  Dragonfly Documentation stylesheet  -->
    <link href="css/dragonfly-docs.min.css" rel="stylesheet">
    <!-- Google Fonts - Lato -->
    <link href="http://fonts.googleapis.com/css?family=Lato:300,400" rel="stylesheet">
    <!-- Font Awesome Icons -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">
    <!-- CSS Animations -->
    <link href="http://cdnjs.cloudflare.com/ajax/libs/animate.css/3.1.1/animate.min.css" rel="stylesheet">
    <!--  Source Code Pro  -->
    <link href="http://fonts.googleapis.com/css?family=Source+Code+Pro" rel="stylesheet">
    <!--  Slippry Slideshow -->
    <link href="../assets/css/slippry.min.css" rel="stylesheet">
    <!--  Sidebar Effects  -->
    <link href="css/sidebarEffects.min.css" rel="stylesheet">
    <!--  Highlighter  -->
    <link href="highlighter/customTheme.min.css" rel="stylesheet">

    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r;
            i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date();
            a = s.createElement(o),
            m = s.getElementsByTagName(o)[0];
            a.async = 1;
            a.src = g;
            m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'http://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-51308611-2', 'influencethemes.com');
        ga('send', 'pageview');
    </script>
</head>

<body>

    <div id="st-container" class="st-container">
        <!-- content push wrapper -->
        <div class="st-pusher">

            <nav class="st-menu st-effect-3" id="menu-3">
                <h2 class="icon icon-lab">Sidebar</h2>
                <ul>
                    <li><a href="index.php"><i class="fa fa-paper-plane"></i>Get Started</a>
                    </li>
                    <li><a href="index.php"><i class="fa fa-tasks"></i>Documentation</a>
                    </li>
                    <li><a href="php-tutorial.php#here"><i class="fa fa-life-ring"></i>PHP Tutorial</a>
                    </li>
                    <li><a href="elements.php#here"><i class="fa fa-code"></i>Elements - Code Blocks</a>
                    </li>
                    <li><a href="changelog.php#here"><i class="fa fa-check-square-o"></i>Changelog</a>
                    </li>
                    <li><a href="license-and-credits.php#here"><i class="fa fa-file-text"></i>License &amp; Credits</a>
                    </li>
                </ul>
            </nav>

            <div class="st-content">
                <!-- this is the wrapper for the content -->
                <div class="st-content-inner">
                    <!-- extra div for emulating position:fixed of the menu -->
