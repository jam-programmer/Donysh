/*
===========================================================================
 EXCLUSIVE ON themeforest.net
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 Template Name   : Dome - Building & Construction Business HTML5 Template
 Author          : PX Draft
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 Copyright (c) 2018 - Dome - Building & Construction Business HTML5 Template
===========================================================================
*/

(function($){
  "use strict";
  var Dome = {};
  $.fn.exists = function () {
        return this.length > 0;
    };

  /* ---------------------------------------------- /*
   * Pre load
  /* ---------------------------------------------- */
  Dome.PreLoad = function() {
    document.getElementById("loading").style.display = "none"; 
  }

  /*--------------------
        * Header Class
    ----------------------*/
    Dome.HeaderSticky = function(){
       $(".navbar-toggler").on("click", function(a) {
            a.preventDefault(), 
            $(".navbar").addClass("fixed-header")
        });
    }

    /*--------------------
        * Menu Close
    ----------------------*/
    Dome.MenuClose = function(){
      $('.navbar-nav .nav-link').on('click', function() {
       var toggle = $('.navbar-toggler').is(':visible');
       if (toggle) {
         $('.navbar-collapse').collapse('hide');
       }
      });
    }

  /* ---------------------------------------------- /*
   * Header Height
  /* ---------------------------------------------- */
  Dome.HeaderHeight = function(){
    var HHeight = $('.header-height .fixed-header-bar').height()
      $('header').height(HHeight);  
  }

  /* ---------------------------------------------- /*
   * Header Fixed
  /* ---------------------------------------------- */
  Dome.HeaderFixd = function() {
    var HscrollTop  = $(window).scrollTop();  
      if (HscrollTop >= 30) {
         $('.navbar').addClass('fixed-header');
      }
      else {
         $('.navbar').removeClass('fixed-header');
      }
  }

  /*--------------------
        * One Page
    ----------------------*/
    Dome.OnePage = function(){
        $('header a[href*="#"]:not([href="#"]), .got-to a[href*="#"]:not([href="#"])').on('click', function() {
            if (location.pathname.replace(/^\//,'') === this.pathname.replace(/^\//,'') || location.hostname === this.hostname) {
              var target = $(this.hash);
                  target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
                  if (target.length) {
                    $('html,body').animate({
                      scrollTop: target.offset().top - 70,
                      }, 1000);
                      return false;
                  }
            }
        });
    }


  /* ---------------------------------------------- /*
   * Search Box
  /* ---------------------------------------------- */
  Dome.SearchBox = function() {
    var SearchToggle = $(".search_click")
    SearchToggle.on("click", function() {
          $('.search-box').toggleClass("searh-form-open");
      });
  }

  /* ---------------------------------------------- /*
   * Mega Menu
  /* ---------------------------------------------- */

  Dome.MegaMenu = function() {
    var mDropdown = $(".m-dropdown-toggle") 
    mDropdown.on("click", function() {
          $(this).parent().toggleClass("open-menu-parent");
          $(this).next('ul').toggleClass("open-menu");
          $(this).toggleClass("open");
      });
  }

  /*--------------------
        * Progress Bar 
    ----------------------*/
    Dome.ProgressBar = function(){
        $(".progress .progress-bar").each(function () {
          var bottom_object = $(this).offset().top + $(this).outerHeight();
          var bottom_window = $(window).scrollTop() + $(window).height();
          var progressWidth = $(this).attr('aria-valuenow') + '%';
          if(bottom_window > bottom_object) {
            $(this).css({
              width : progressWidth
            });
          }
        });
    }

    /* ---------------------------------------------- /*
    * accordion
  /* ---------------------------------------------- */
  Dome.Accordion = function() {
    $('.accordion').each(function (i, elem) {
          var $elem = $(this),
             $acpanel = $elem.find(".Dome-group > .Dome-des"),
             $acsnav =  $elem.find(".Dome-group > .Dome-heading");
            $acpanel.hide().first().slideDown("easeOutExpo");
            $acsnav.first().parent().addClass("Dome-active");
            $acsnav.on('click', function () {
              if(!$(this).parent().hasClass("Dome-active")){
                var $this = $(this).next(".Dome-des");
                $acsnav.parent().removeClass("Dome-active");
                $(this).parent().addClass("Dome-active");
                $acpanel.not($this).slideUp("easeInExpo");
                $(this).next().slideDown("easeOutExpo");
              }else{
                 $(this).parent().removeClass("Dome-active");
                 $(this).next().slideUp("easeInExpo");
              }
              return false;
          });
      });
  }

    /*--------------------
    * Counter JS
    ----------------------*/
    var a = 0;
    Dome.Counter = function(){
      var oTop = $('.counter-box').offset().top - window.innerHeight;
        if (a == 0 && $(window).scrollTop() > oTop) {
          $('.count').each(function () {
                $(this).prop('Counter',0).animate({
                    Counter: $(this).text()
                }, {
                    duration: 4000,
                    easing: 'swing',
                    step: function (now) {
                        $(this).text(Math.ceil(now));
                    }
                });
            });
          a = 1;
        }
    }


    /*--------------------
    * OwlSlider
    ----------------------*/
    Dome.Owl = function () {
      var owlslider = jQuery("div.owl-carousel");
      if(owlslider.length > 0) {  
         loadScript(plugin_track + 'owl-carousel/js/owl.carousel.min.js', function() {
           owlslider.each(function () {
            var $this = $(this),
                $items = ($this.data('items')) ? $this.data('items') : 9,
                $loop = ($this.attr('data-loop')) ? $this.data('loop') : true,
                $navdots = ($this.data('nav-dots')) ? $this.data('nav-dots') : false,
                $navarrow = ($this.data('nav-arrow')) ? $this.data('nav-arrow') : false,
                $autoplay = ($this.attr('data-autoplay')) ? $this.data('autoplay') : true,
                $autospeed = ($this.attr('data-autospeed')) ? $this.data('autospeed') : 5000,
                $smartspeed = ($this.attr('data-smartspeed')) ? $this.data('smartspeed') : 1000,
                $autohgt = ($this.data('autoheight')) ? $this.data('autoheight') : false,
                $space = ($this.attr('data-space')) ? $this.data('space') : 30;    
           
                $(this).owlCarousel({
                    loop: $loop,
                    items: $items,
                    responsive: {
                      0:{items: $this.data('xx-items') ? $this.data('xx-items') : 2},
                      480:{items: $this.data('xs-items') ? $this.data('xs-items') : 3},
                      768:{items: $this.data('sm-items') ? $this.data('sm-items') : 5},
                      980:{items: $this.data('md-items') ? $this.data('md-items') : 5},
                      1200:{items: $items}
                    },
                    dots: $navdots,
                    autoplayTimeout:$autospeed,
                    smartSpeed: $smartspeed,
                    autoHeight:$autohgt,
                    margin:$space,
                    nav: $navarrow,
                    navText:["<i class='ti-arrow-left'></i>","<i class='ti-arrow-right'></i>"],
                    autoplay:  true ,
                    autoplayHoverPause: true   
                }); 
           }); 
         });
      }
    }

  /* ---------------------------------------------- /*
     * lightbox gallery
    /* ---------------------------------------------- */
    Dome.Gallery = function() {
      if ($(".lightbox-gallery").exists() || $(".popup-youtube, .popup-vimeo, .popup-gmaps").exists()){
        loadScript(plugin_track + 'magnific/jquery.magnific-popup.min.js', function() {
          if ($(".popup-youtube, .popup-vimeo, .popup-gmaps").exists()) {
                $('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
                      disableOn: 700,
                      type: 'iframe',
                      mainClass: 'mfp-fade',
                      removalDelay: 160,
                      preloader: false,
                      fixedContentPos: false
                });
            }
        });
      }
    }

    /*--------------------
    * Masonry
    ----------------------*/
    Dome.masonry = function () {
      var portfolioWork = $('.portfolio-content');
      if ($(".portfolio-content").exists()){
        loadScript(plugin_track + 'isotope/isotope.pkgd.min.js', function() {
          if ($(".portfolio-content").exists()){
              $(portfolioWork).isotope({
                resizable: false,
                itemSelector: '.portfolio-item',
                layoutMode: 'masonry',
                filter: '*'
              });
              //Filtering items on portfolio.html
              var portfolioFilter = $('.filter li');
              // filter items on button click
              $(portfolioFilter).on( 'click', function() {
                var filterValue = $(this).attr('data-filter');
                portfolioWork.isotope({ filter: filterValue });
              });
              //Add/remove class on filter list
              $(portfolioFilter).on( 'click', function() {
                $(this).addClass('active').siblings().removeClass('active');
              });
          }
        });
      }
  }

  /*--------------------
        * Tyoe It
    ----------------------*/
    Dome.mTypeIt = function() {
      if ($(".type_it").exists()){
    loadScript(plugin_track + 'typeit-master/typeit.min.js', function() {
      if ($(".type_it").exists()){
        new TypeIt('.type_it', {
                speed: 200,
                loop:true,
                strings: [
                  'Designer',
                  'Developer'
                ],
                breakLines: false
            }); 
      }
      });
    }
    }
  

  /* ---------------------------------------------- /*
   * All Functions
  /* ---------------------------------------------- */
    // loadScript
    var plugin_track = 'static/plugin/';
  var _arr  = {};
  function loadScript(scriptName, callback) {
      if (!_arr[scriptName]) {
        _arr[scriptName] = true;
        var body = document.getElementsByTagName('body')[0];
        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.src = scriptName;
        // then bind the event to the callback function
        // there are several events for cross browser compatibility
        // script.onreadystatechange = callback;
        script.onload = callback;
        // fire the loading
        body.appendChild(script);
      } else if (callback) {
        callback();
      }
  };

  // Window on Load
  $(window).on("load", function(){
    Dome.PreLoad();
  });
  // Document on Ready
  $(document).on("ready", function(){
    Dome.mTypeIt(),
    Dome.HeaderFixd(),
    Dome.masonry(),
    Dome.OnePage(),
    Dome.Counter(),
    Dome.HeaderHeight(),
    Dome.HeaderSticky(),
    Dome.MenuClose(),
    Dome.Gallery(),
    Dome.Accordion(),
    Dome.ProgressBar(),
    Dome.MegaMenu(),
    Dome.Owl(),
    Dome.SearchBox();
    
  });

  // Document on Scrool
  $(window).on("scroll", function(){
    Dome.ProgressBar(),
    Dome.HeaderFixd();
  });

  // Window on Resize
  $(window).on("resize", function(){
    Dome.HeaderHeight();
  });


})(jQuery);