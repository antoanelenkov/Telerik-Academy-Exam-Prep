var controllerHelpers=(function(){
    function fixDate(item) {
        var newItem = Object.create(item);
        newItem.shareDate = moment(item.shareDate).format('MMM Do YYYY, hh:mm');
        return newItem;
    }

    function groupByCategory(item) {
        return item.category;
    }

    function parseGroups(items, category) {
        return {
            category:category,
            items:items
        };
    }

    function filterByCategory(category) {
        return function(group) {
            return group.category.toLowerCase() === category.toLowerCase();
        };
    }


    return {
        fixDate:fixDate
    }
}());