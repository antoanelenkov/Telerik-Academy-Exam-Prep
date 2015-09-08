var templates=(function(){
    var handlebars = window.handlebars || window.Handlebars,
        Handlebars = window.handlebars || window.Handlebars;


    function get(name){
        var url='templates/'+name+'.html';

        var promise=new Promise(function(resolve,reject){
            $.get(url,function(templateHTML){
                var template = handlebars.compile(templateHTML);
                resolve(template);
            })
        });

        return promise;
    }

    return {get:get};
})();
