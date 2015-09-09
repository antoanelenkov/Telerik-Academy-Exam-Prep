(function() {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "500",
        "hideDuration": "500",
        "timeOut": "2000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    var sammyApp = Sammy('#content', function() {

        this.get('#/',function(context){
            context.redirect('#/posts');
        })
        this.get('#/home',homeController.getHomePage)

        this.get('#/login',usersController.signIn);
        this.get('#/register',usersController.signUp);

        this.get('#/posts', postsController.getAll);
        this.get('#/posts/add', postsController.addPost);

    });

    $(function() {
        sammyApp.run('#/home');

        var $loginBtn = $("#main-login-btn"),
            $logoutBtn = $("#main-logout-btn");
console.log(data.users.hasUser())
        if(data.users.hasUser()){
            $('#login-form').addClass('hidden');

            $logoutBtn.on('click', function () {
                data.users.signOut()
                    .then(function () {
                        document.location = '#/posts';
                        document.location.reload(true);
                    })

                return false;
            });
        }
        else{
            $('#logout-form').addClass('hidden');
            $loginBtn.on('click', function () {
                document.location = '#/login';
                document.location.reload(true);

                return false;
            });
        }
    });
}());
