var usersController = function() {
    var user={};

    function signIn(context) {
        templates.get('login')
            .then(function (template) {
                context.$element().html(template());

                var $regRedirectBtn = $('#btn-redirect-register');
                var $btnLogin = $('#btn-login');

                $regRedirectBtn.on('click', function () {
                    context.redirect('#/register');
                })

                $btnLogin.on('click', function () {
                    user.username = $('#tb-username-login').val();
                    user.password = $('#tb-password-login').val();

                    data.users.signIn(user)
                        .then(function (respond) {
                            if(respond='error'){
                                toastr.error('Invalid username or password');
                                return;
                            }
                            document.location = '#/home';
                            document.location.reload(true);
                        });

                    return false;
                })
            })
    }

    function signUp(context) {
        templates.get('register')
            .then(function (template) {
                context.$element().html(template());
            })
            .then(function () {
                console.log(3333333)
                var $regBtn = $('#btn-register');

                $regBtn.on('click', function () {
                    user.username = $('#tb-username-register').val();
                    user.password = $('#tb-password-register').val();

                    if(!validator.userRegistrationValidation.usernameValidation(user.username)){
                        console.log(444)
                        toastr.error('Username can contain only Latin letters, digits and the characters "_" and "." and be between 6 and 30 symbols.');

                        $('#tb-username-register').val('');

                        return;
                    }

                    data.users.register(user)
                        .then(function (respond) {
                            if(respond.message===undefined){
                                toastr.success('You are successfully registered. If you want to add posts, log in with your username and password');
                            }
                            else{
                                toastr.error('invalid username or password');
                                return;
                            }
                            context.redirect('#/home');
                        })
                })
            })
    }

    return {
        signIn: signIn,
        signUp: signUp
    };
}();
