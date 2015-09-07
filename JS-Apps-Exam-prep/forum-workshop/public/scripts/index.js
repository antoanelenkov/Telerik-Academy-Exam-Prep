var sammy = Sammy('#content', function () {
    var $content = $('#content'),
        $regBtn,
        $loginBtn;

    this.get('#/', function (context) {
        var currentUser=data.users.getCurrent();

        if(currentUser===null){
            context.redirect('#/login');
        }
        else{
            context.redirect('#/threads');
        }

        console.log('inital page');
    })

    this.get('#/login', function (context) {
        templates.get('login')
            .then(function (source) {
                $content.html(source);
            })
            .then(function () {
                $regBtn = $('#btn-register');
                $regBtn.on('click', function () {
                    context.redirect('#/register');
                })
            })


        console.log('login page');
    })

    this.get('#/register', function () {
        templates.get('register')
            .then(function (source) {
                $content.html(source);
            })

        console.log('register page');
    })

    this.get('#/threads', function () {
        var threads;
        data.posts.getAll()
            .then(function (respond) {
                threads = respond.result;

                return templates.get('threads');
            })
            .then(function (source) {
                $content.html(source(threads));
            });

        console.log('inital page');
    })

    this.get('#/threads/add', function () {
        console.log('add post');
    })

    this.get('#/threads/:id', function () {
        console.log('get post by id');
    })

    this.get('#/threads/:id/messages/add', function () {
        console.log('add message to post with certain id');
    })

});

$(function () {
    sammy.run('#/');
});
