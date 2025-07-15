$(function ($) {
    var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
    $('ul.nav-sidebar a').each(function () {
        if (this.href === path) {
            $(this).addClass('active');
        }
    });
});
$(document).ready(function () {
    var url = window.location;


    // for sidebar menu entirely but not cover treeview
    $('ul.sidebar-menu tree a').filter(function () {
        return this.href == url;
    }).addClass('active');

    // for treeview is like a submenu
    $('ul.treeview-menu a').filter(function () {
        return this.href == url;
    }).parentsUntil(".sidebar-menu > .treeview-menu").addClass('menu-open active').css("display","block").prev('a').addClass('active');
});
