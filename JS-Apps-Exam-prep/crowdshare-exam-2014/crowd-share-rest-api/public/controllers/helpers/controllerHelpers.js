var controllerHelpers=(function(){
    function fixDate(item) {
        var newItem = Object.create(item);
        newItem.postDate = moment(item.postDate).format('MMM Do YYYY, hh:mm');
        return newItem;
    }


    return {
        fixDate:fixDate
    }
}());