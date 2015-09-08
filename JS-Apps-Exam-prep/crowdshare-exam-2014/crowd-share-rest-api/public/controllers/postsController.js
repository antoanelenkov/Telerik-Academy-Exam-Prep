var postsController = function () {
    function getAll(context) {
        var posts;

        data.posts.get().then(function (source) {
            posts = source;
        }).then(function () {
            return templates.get('posts');
        }).then(function (template) {
            context.$element().html(template(posts));
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
