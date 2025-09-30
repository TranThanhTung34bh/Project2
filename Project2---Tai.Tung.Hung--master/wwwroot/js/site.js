// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/* site.js - jQuery UI behaviors */
$(document).ready(function () {

    // 1) Menu dropdown slide on hover (desktop)
    $('.nav-item.dropdown').hover(function () {
        $(this).addClass('show');
        $(this).find('.dropdown-menu').stop(true, true).fadeIn(150).addClass('show');
    }, function () {
        $(this).removeClass('show');
        $(this).find('.dropdown-menu').stop(true, true).fadeOut(100).removeClass('show');
    });

    // 2) Simple slider (expects .site-slider > .slide elements)
    (function () {
        var $slides = $('.site-slider .slide');
        if ($slides.length === 0) return;
        var index = 0;
        $slides.hide().eq(0).show();
        setInterval(function () {
            $slides.eq(index).fadeOut(600);
            index = (index + 1) % $slides.length;
            $slides.eq(index).fadeIn(600);
        }, 4000);
    })();

    // 3) Scroll to top button (auto-insert)
    var $btn = $('<button class="scroll-top" title="Lên đầu trang">↑</button>');
    $('body').append($btn);
    $btn.hide();
    $(window).on('scroll', function () {
        if ($(this).scrollTop() > 200) $btn.fadeIn();
        else $btn.fadeOut();
    });
    $btn.on('click', function () { $('html, body').animate({ scrollTop: 0 }, 500); });

    // 4) Hover effect on product cards - add class on hover
    $('.product-card').hover(function () {
        $(this).addClass('hovered');
    }, function () {
        $(this).removeClass('hovered');
    });

    // 5) Simple client-side form validation for forms with .validate-form
    $('.validate-form').on('submit', function (e) {
        var valid = true;
        $(this).find('[data-required="true"]').each(function () {
            if ($.trim($(this).val()) === '') {
                valid = false;
                $(this).addClass('input-error');
            } else {
                $(this).removeClass('input-error');
            }
        });
        if (!valid) {
            e.preventDefault();
            // Try SweetAlert if loaded, otherwise alert
            if (typeof Swal !== 'undefined') {
                Swal.fire('Lỗi', 'Vui lòng điền đủ thông tin cần thiết.', 'warning');
            } else {
                alert('Vui lòng điền đủ thông tin cần thiết.');
            }
        }
    });

});
