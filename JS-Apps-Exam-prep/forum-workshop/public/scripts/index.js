var sammy = Sammy('#content', function () {
    var $content = $('#content');
    var user = {},
        that = this;

    renderLoginAndLogoutButton();

    var $loginBtn = $("#threads-login-btn"),
        $logoutBtn = $("#threads-logout-btn");

    $logoutBtn.on('click', function () {
        data.users.logout()
            .then(function () {
                console.log('in logout btn');
                renderLoginAndLogoutButton();
                window.location.hash = ('#/threads');

            })
    });

    $loginBtn.on('click', function () {
        renderLoginAndLogoutButton();
        window.location.hash = ('#/login');
    });


    function renderLoginAndLogoutButton() {
        data.users.getCurrent()
            .then(function (user) {
                if (user === null) {
                    $loginBtn.removeClass('hidden');
                    $logoutBtn.addClass('hidden');
                }
                else {
                    $loginBtn.addClass('hidden');
                    $logoutBtn.removeClass('hidden');
                }
            });
    }


    that.get('#/', function (context) {
        context.redirect('#/threads');
    })

    that.get('#/login', function (context) {
        templates.get('login')
            .then(function (source) {
                $content.html(source);
            })
            .then(function () {
                var $regRedirectBtn = $('#btn-redirect-register');
                var $btnLogin = $('#btn-login');

                $regRedirectBtn.on('click', function () {
                    context.redirect('#/register');
                })

                $btnLogin.on('click', function () {
                    user.username = $('#tb-username-login').val();
                    user.password = $('#tb-password-login').val();

                    data.users.login(user)
                        .then(function () {
                            renderLoginAndLogoutButton();
                        })
                        .then(function () {
                            context.redirect('#/threads');
                        });
                })
            })
    })

    that.get('#/register', function (context) {
        templates.get('register')
            .then(function (source) {
                $content.html(source);
            })
            .then(function () {
                var $regBtn = $('#btn-register');

                $regBtn.on('click', function () {
                    user.username = $('#tb-username-register').val();
                    user.password = $('#tb-password-register').val();

                    data.users.register(user)
                        .then(function () {
                            renderLoginAndLogoutButton();
                        })
                        .then(function () {
                            context.redirect('#/threads');
                            alert('You are registred, please log in with your username and password');
                        })
                })
            })
    })

    var query = {
        page: 0,
        size: 10
    }

    that.get('#/threads', function (context) {
        var threads;


        data.posts.getAll(query)
            .then(function (respond) {
                threads = respond.result;
                return templates.get('threads');
            })
            .then(function (source) {
                $content.html(source(threads));
            })
            .then(function () {
                var $addPostBtn = $('#addThread-btn'),
                    $addPostTitleTb = $('#threadTitle-tb'),
                    $addPostMessageTb = $('#threadMessage-tb'),
                    $previous = $('#previous-btn'),
                    $next = $('#next-btn');


                $previous.on('click', function () {
                    query.page -= 1;
                    console.log('previous')
                    data.posts.getAll(query)
                        .then(function (respond) {
                            threads = respond.result;
                            return templates.get('threads');
                        })
                        .then(function (source) {
                            $content.html(source(threads));
                        })
                        .then(function(){
                            context.redirect('#/');
                        })
                })

                $next.on('click', function () {
                    query.page += 1;
                    console.log('next')
                    data.posts.getAll(query)
                        .then(function (respond) {
                            threads = respond.result;
                            return templates.get('threads');
                        })
                        .then(function (source) {
                            $content.html(source(threads));
                        })
                        .then(function(){
                            context.redirect('#/');
                        })
                })

                $addPostBtn.on('click', function () {
                    var post = {
                        title: $addPostTitleTb.val(),
                        message: $addPostMessageTb.val()
                    }

                    data.posts.addPost(post)
                        .then(function () {
                            context.redirect('#/');
                        })

                })
            })

    })

    that.get('#/threads/add', function () {
        console.log('add post');
    })

    that.get('#/threads/:id', function () {
        console.log('get post by id');
    })

    that.get('#/threads/:id/messages/add', function () {
        console.log('add message to post with certain id');
    })

})

$(function () {
    sammy.run('#/');
});
