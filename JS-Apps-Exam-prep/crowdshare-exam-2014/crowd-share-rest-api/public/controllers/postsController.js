var postsController = function () {
    //1.paging
    var page=0;
    var size=3;

    function getAll(context) {
        //Query String - 1.add parameters and pass them in get function
        var posts;
        var user = context.params.user || '';
        var pattern=context.params.pattern||'';

        data.posts.get(user,pattern).then(function (source) {
            if(source.length>page*size){
                //2.paging
                posts = source.slice(page*size,page*size+size);
            }
        }).then(function () {
            return templates.get('posts');
        }).then(function (template) {
            posts = posts.map(controllerHelpers.fixDate);

            context.$element().html(template(posts));

            $('#search-btn').on('click',function(){
                var pattern=$('#search-tb').val();
                context.redirect('#/posts?pattern='+pattern);
            });

            $('#previous-btn').on('click',function(){
                //3.paging
                if(page!=0) {
                    page -= 1;
                    $('#next-btn').removeClass('hidden');
                }

                context.redirect('#/')
            });

            $('#next-btn').on('click',function(){

                if(!(posts.length<size)){
                    page+=1;
                    $('#previous-btn').removeClass('hidden');
                }

                context.redirect('#/')
            });
        });
    }


    function addPost(context) {
        if (!data.users.hasUser()) {
            toastr.info('You must first log in!')
            context.redirect('#/login');
            return;
        }

        templates.get('addPost')
            .then(function (template) {
                context.$element().html(template());

                var $addPostBtn = $('#addPost-btn'),
                    $addPostTitleTb = $('#postTitle-tb'),
                    $addPostMessageTb = $('#postBody-tb');

                $addPostBtn.on('click', function () {
                    var post = {
                        title: $addPostTitleTb.val(),
                        body: $addPostMessageTb.val()
                    }

                    data.posts.add(post)
                        .then(function () {
                            context.redirect('#/posts');
                        })
                });
            });
    }

    return {
        getAll: getAll,
        addPost: addPost
    };
}();
