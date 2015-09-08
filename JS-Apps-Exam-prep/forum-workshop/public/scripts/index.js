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
                var $previous = $('#previous-btn'),
                    $next = $('#next-btn');


                $previous.on('click', function () {
                    if(query.page!==0){
                        query.page -= 1;
                    }

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
                    data.posts.getAll(query)
                        .then(function (respond) {
                            threads = respond.result;

                            if(threads.length===0){
                                query.page -= 1
                                return null;
                            }

                            return templates.get('threads');
                        })
                        .then(function (source) {
                            if(!!source){
                                $content.html(source(threads));
                            }
                        })
                        .then(function(){
                            context.redirect('#/');
                        })
                })
            })

    })

    that.get('#/threads/add', function (context) {

        templates.get('addThread')
            .then(function (source) {
                $content.html(source);

                var $addPostBtn = $('#addThread-btn'),
                    $addPostTitleTb = $('#threadTitle-tb'),
                    $addPostMessageTb = $('#threadMessage-tb');

                $addPostBtn.on('click', function () {
                    var post = {
                        title: $addPostTitleTb.val(),
                        message: $addPostMessageTb.val()
                    }

                    data.posts.addPost(post)
                        .then(function () {
                            context.redirect('#/threads');
                        })

                })
            })
    })

    that.get('#/threads/:id', function (context) {
        var thread;
        data.posts.getById(context.params.id)
            .then(function(res){
                thread=res.result;

                return templates.get('thread');
            })
            .then(function (source){
                $content.html(source(thread));
            })
    });

    that.get('#/threads/:id/messages', function (context) {
        templates.get('addMessage')
            .then(function (source) {
                $content.html(source);

                var $addMsgBtn = $('#addMsg-btn'),
                    $addMsgMessageTb = $('#MsgMessage-tb');

                $addMsgBtn.on('click', function () {
                    var post = {
                        text: $addMsgMessageTb.val()
                    }
                    data.posts.addMessageToPost(context.params.id,post)
                        .then(function (res) {
                            context.redirect('#/threads');
                        })

                })
            })
    })

})

$(function () {
    sammy.run('#/');
});
