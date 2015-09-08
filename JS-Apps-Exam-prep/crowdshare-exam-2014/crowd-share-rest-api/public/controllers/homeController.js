var homeController = function() {
    function getHomePage(context) {
        templates.get('home')
            .then(function(template) {
                context.$element().html(template());
            });
    }

    return {
        getHomePage: getHomePage
    };
}();