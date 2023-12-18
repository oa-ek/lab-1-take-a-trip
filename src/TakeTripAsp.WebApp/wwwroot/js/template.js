(function ($) {
    'use strict';
    $(function () {
        // ... (���� �����)

        function addActiveClass(element, currentPath) {
            // ... (����� ���������� ��������)
        }

        var current = location.pathname.split("/").slice(-1)[0].replace(/^\/|\/$/g, '');
        $('.nav li a', sidebar).each(function () {
            var $this = $(this);
            addActiveClass($this, current);
        });

        $('.horizontal-menu .nav li a').each(function () {
            var $this = $(this);
            addActiveClass($this, current);
        });

        sidebar.on('show.bs.collapse', '.collapse', function () {
            sidebar.find('.collapse.show').collapse('hide');
        });

        applyStyles();

        function applyStyles() {
            if (!body.hasClass("rtl")) {
                if ($('.settings-panel .tab-content .tab-pane.scroll-wrapper').length) {
                    const settingsPanelScroll = new PerfectScrollbar('.settings-panel .tab-content .tab-pane.scroll-wrapper');
                }
                if ($('.chats').length) {
                    const chatsScroll = new PerfectScrollbar('.chats');
                }
                if (body.hasClass("sidebar-fixed")) {
                    if ($('#sidebar').length) {
                        var fixedSidebarScroll = new PerfectScrollbar('#sidebar .nav');
                    }
                }
            }
        }

        $('[data-toggle="minimize"]').on("click", function () {
            if ((body.hasClass('sidebar-toggle-display')) || (body.hasClass('sidebar-absolute'))) {
                body.toggleClass('sidebar-hidden');
            } else {
                body.toggleClass('sidebar-icon-only');
            }
        });

        // Checkbox and radios
        // ³������� PerfectScrollbar ��� �������� � ����������
        // �������, �� �� ����� �������� � ����������
        // $(".form-check label,.form-radio label").append('<i class="input-helper"></i>');

        $('[data-toggle="horizontal-menu-toggle"]').on("click", function () {
            $(".horizontal-menu .bottom-navbar").toggleClass("header-toggled");
        });

        var navItemClicked = $('.horizontal-menu .page-navigation >.nav-item');
        navItemClicked.on("click", function (event) {
            if (window.matchMedia('(max-width: 991px)').matches) {
                if (!($(this).hasClass('show-submenu'))) {
                    navItemClicked.removeClass('show-submenu');
                }
                $(this).toggleClass('show-submenu');
            }
        });

        $(window).scroll(function () {
            if (window.matchMedia('(min-width: 992px)').matches) {
                var header = $('.horizontal-menu');
                if ($(window).scrollTop() >= 70) {
                    $(header).addClass('fixed-on-scroll');
                } else {
                    $(header).removeClass('fixed-on-scroll');
                }
            }
        });
    });

    $('#navbar-search-icon').click(function () {
        $("#navbar-search-input").focus();
    });

})(jQuery);
