var postsController = function () {
    //1.paging
    var currentPage= 0;
    var size= 3;
    var sortByTitleASC=true;
    var sortByDateASC=true;

    function getAll(context) {
        //Query String - 1.add parameters and pass them in get function
        var posts;
        var postsLength;
        var user = context.params.user || '';
        var pattern = context.params.pattern || '';
        var page=context.params.pattern||currentPage;
        var size=context.params.pattern||3;
        var titleASC=context.params.titleASC||'';
        var dateASC=context.params.dateASC||'';
        console.log(currentPage)


        data.posts.get(user, pattern).then(function (source) {
            postsLength=source.length;
            //1.sorting
            if(titleASC){
                if(sortByTitleASC){
                    posts=_.sortBy(source,'title');
                    sortByTitleASC=false;
                }
                else{

                    posts=_.sortBy(source,'title').reverse();
                    sortByTitleASC=true;
                }

                //2.paging
                posts = posts.slice(page * size, page * size + size);
            }else if(dateASC){
                if(sortByDateASC){
                    posts=_.sortBy(source,'date');
                    sortByDateASC=false;
                }
                else{

                    posts=_.sortBy(source,'date').reverse();
                    sortByDateASC=true;
                }

                //2.paging
                posts = posts.slice(page * size, page * size + size);
            }else{
                posts = source.slice(page * size, page * size + size);
            }


        }).then(function () {
            return templates.get('posts');
        }).then(function (template) {
            posts = posts.map(controllerHelpers.fixDate);

            context.$element().html(template(posts));

            $('#search-btn').on('click', function () {
                var pattern = $('#search-tb').val();
                currentPage = 0;
                context.redirect('#/posts?pattern=' + pattern);
            });

            $('#sort-by-title-btn').on('click', function () {
                context.redirect('#/posts?titleASC='+sortByTitleASC);
            });

            $('#sort-by-date-btn').on('click', function () {
                context.redirect('#/posts?dateASC='+sortByDateASC);
            });

            $('#previous-btn').on('click', function () {
                //3.paging
                if (currentPage != 0) {
                    currentPage -= 1;
                }
                else{
                    $('#previous-btn').addClass('hidden');
                }


                context.redirect('#/');
            });

            $('#next-btn').on('click', function () {
                if ((currentPage+1)*size < postsLength) {
                    currentPage += 1;
                    $('#previous-btn').removeClass('hidden');
                }
                else{
                    $('#next-btn').addClass('hidden');
                }

                //context.redirect('#/');
                context.redirect('#/');
            });

            $('.user-posts-btn').on('click', function (ev) {
                var user = $(ev.target).text();
                currentPage = 0;

                context.redirect('#/posts?user=' + user);
            })
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
