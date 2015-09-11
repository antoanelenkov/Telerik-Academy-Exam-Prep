var homeController = function() {
    function getHomePage(context) {
        templates.get('info')
            .then(function(template) {
                context.$element().html(template());
            });
    }

    return {
        getHomePage: getHomePage
    };
}();