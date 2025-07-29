(function ($) {
 "use strict";
  
	var $tabs = $('.nav-year li');
	var flagscroll=true;
	
	$('.about-count').each(function () {
		$(this).prop('Counter',0).animate({
			Counter: $(this).text()
			}, {
			duration: 4000,
			easing: 'swing',
			step: function (now) {
				$(this).text(Math.ceil(now).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
			}
		});
	});
	
	$(".events-list .row > div").slice(0, 8).show();
	$(".excursions-list .row > div").slice(0, 8).show();
	$(".teachers-list .row > div").slice(0, 8).show();
	$(".gallery-list .container > .row").slice(0, 4).show();
	$(".academics-content .container > .row").slice(0, 6).show();


	$("div").on("mouseleave", function(){	
	
		if ($(this).hasClass("events-single-location")) { 
			$('.events-single-location iframe').css("pointer-events", "none"); 
		}
		
		if ($(this).hasClass("excursions-single-location")) { 
			$('.excursions-single-location iframe').css("pointer-events", "none"); 
		}	  
	});
	
	$(window).on("scroll", function(){

		var y = $(window).scrollTop();
		if(  y > 2000 && flagscroll === true ) {
			flagscroll=false;
			$('.home-count').each(function () {
				$(this).prop('Counter',0).animate({
					Counter: $(this).text()
					}, {
					duration: 4000,
					easing: 'swing',
					step: function (now) {
						$(this).text(Math.ceil(now).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
					}
				});
			});
		}
	});

	$("a,section,div,span,li,input[type='text'],input[type='button'],tr,button").on("click", function(){
		
		if ($(this).hasClass("events-single-location")) { 
			$('.events-single-location iframe').css("pointer-events", "auto");
		}
		
		if ($(this).hasClass("excursions-single-location")) { 
			$('.excursions-single-location iframe').css("pointer-events", "auto");
		}
		
		if ($(this).hasClass("yr-prev")) { 
			$tabs.filter('.active').prev('li').find('a[data-toggle="tab"]').tab('show');
			return false;
		}
		
		if ($(this).hasClass("yr-next")) { 
			$tabs.filter('.active').next('li').find('a[data-toggle="tab"]').tab('show');
			return false;
		}
		
		if ($(this).hasClass("events-load-more")) { 
			$(".events-list .row > div:hidden").slice(0, 4).slideDown();
			if ($(".events-list .row > div:hidden").length === 0) {
				$(".events-load-more").fadeOut('slow');
			}
			$('html,body').animate({
				scrollTop: $(this).offset().top-600
			}, 1500);
		}
		
		if ($(this).hasClass("excursions-load-more")) { 
			$(".excursions-list .row > div:hidden").slice(0, 4).slideDown();
			if ($(".excursions-list .row > div:hidden").length === 0) {
				$(".excursions-load-more").fadeOut('slow');
			}
			$('html,body').animate({
				scrollTop: $(this).offset().top-600
			}, 1500);
		}
		
		if ($(this).hasClass("teachers-load-more")) { 
			$(".teachers-list .row > div:hidden").slice(0, 4).slideDown();
			if ($(".teachers-list .row > div:hidden").length === 0) {
				$(".teachers-load-more").fadeOut('slow');
			}
			$('html,body').animate({
				scrollTop: $(this).offset().top-600
			}, 1500);
		}
		
		if ($(this).hasClass("gallery-load-more")) { 
			$(".gallery-list .container > .row:hidden").slice(0, 1).slideDown();
			if ($(".gallery-list .container > .row:hidden").length === 0) {
				$(".gallery-load-more").fadeOut('slow');
			}
			$('html,body').animate({
				scrollTop: $(this).offset().top-200
			}, 1500);
		}
		
		if ($(this).hasClass("academics-load-more")) { 
			$(".academics-content .container > .row:hidden").slice(0, 6).slideDown();
			if ($(".academics-content .container > .row:hidden").length === 0) {
				$(".academics-load-more").fadeOut('slow');
			}
			$('html,body').animate({
				scrollTop: $(this).offset().top-1100
			}, 1500);
		}
		
		if ($(this).hasClass("closecanvas")) { 
			$("body").removeClass("offcanvas-stop-scrolling");
		}
		
		
	});
	
	 $('.datepicker').datepicker({
		format: 'mm/dd/yyyy',
		todayHighlight: true,
		autoclose: true
	});

	$('.skillbar').each(function(){
		$(this).find('.skillbar-bar').animate({
			width:$(this).attr('data-percent')
		},2000);
	});

	  
	  
})(jQuery);

function updateDateTime() {
		const now = new Date();
	const options = {
		weekday: 'short', year: 'numeric', month: 'short',
	day: 'numeric', hour: '2-digit', minute: '2-digit', second: '2-digit'
		};
	document.getElementById('currentDateTime').textContent = now.toLocaleString('en-IN', options);
	}

setInterval(updateDateTime, 1000);
updateDateTime();





document.addEventListener("DOMContentLoaded", function () {
	const heroContent = document.querySelector('.hero-content');

	const bgImages = [
		'assets/images/auth-bg.jpg',
		'assets/images/carousel/DSC_5950.jpg',
		'assets/images/carousel/DSC_4121.jpg',
		'assets/images/carousel/slider1.jpeg'
	];

	let current = 0;

	function changeBackground() {
		heroContent.style.backgroundImage = `url(${bgImages[current]})`;
		current = (current + 1) % bgImages.length;
	}

	// Initial set
	changeBackground();

	// Rotate every 10 seconds
	setInterval(changeBackground, 10000);
});


let sessionTimer;
let sessionStartTime;

window.startSessionTimer = (dotNetHelper) => {
	sessionStartTime = new Date();

	sessionTimer = setInterval(() => {
		const now = new Date();
		const elapsed = now - sessionStartTime;

		const hours = Math.floor(elapsed / 3600000);
		const minutes = Math.floor((elapsed % 3600000) / 60000);
		const seconds = Math.floor((elapsed % 60000) / 1000);

		const timeString =
			hours.toString().padStart(2, '0') + ':' +
			minutes.toString().padStart(2, '0') + ':' +
			seconds.toString().padStart(2, '0');

		dotNetHelper.invokeMethodAsync('UpdateTimer', timeString);
	}, 1000);
};

window.stopSessionTimer = () => {
	if (sessionTimer) {
		clearInterval(sessionTimer);
		sessionTimer = null;
	}
};




window.initializeFeatherlight = function () {
	$(document).ready(function () {
		if ($.featherlight) {
			$.featherlight.defaults.closeOnClick = 'anywhere';
		}

		// Optional: manually rebind if dynamic content
		$('a[data-featherlight]').featherlight();
	});
};
