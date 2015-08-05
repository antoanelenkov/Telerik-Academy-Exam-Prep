$.fn.tabs = function () {
    var $tabsContainer = $('#tabs-container').addClass('tabs-container');
    var $tabItemTitles = $('.tab-item-title');
    var contents = $('.content');


    for (var i = 0; i < $tabItemTitles.length; i++) {
        console.log($tabItemTitles[i]);
    }

    $tabItemTitles.each(function (index, item) {
        $(item).on('click', function () {
            var $this = $(this);
            var $tabItemsCollection = $('.tabs-container').children();

            $tabItemsCollection.each(function (index, item) {
                $(this).removeClass('current');
                $(this).children('.tab-item-content').hide();
            })
            $this.parent().addClass('current');

            $this.next().show();

        });
    });

    $tabItemTitles.removeClass('current');
};