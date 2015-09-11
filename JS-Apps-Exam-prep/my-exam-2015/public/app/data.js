var data = (function () {
    const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
        LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

    /* Users */
    function register(user) {
        var reqUser = {
            //@@@@@@@@@@@@@@@@@@@@@  Check user.username and user.password
            username: user.username,
            passHash: CryptoJS.SHA1(user.password).toString()
        };
//@@@@@@@@@@@@@@@@@@@@@ Change url and type of request(post,put)
        return jsonRequester.post('api/users', {
            data: reqUser
        })
            .then(function (respond) {
                //@@@@@@@@@@@@@@@@@@@@@ Check and Change respond type
                return respond;
            }, function (error) {
                return error;
            });
    }


    function signIn(user) {
        var reqUser = {
            //@@@@@@@@@@@@@@@@@@@@@ Check and Change username and authCode. Check user.username and user.password
            username: user.username,
            passHash: CryptoJS.SHA1(user.password).toString()
        };

        var options = {
            data: reqUser
        };
//@@@@@@@@@@@@@@@@@@@@@ Change url and type of request(post,put)
        return jsonRequester.put('api/auth', options)
            .then(function (respond) {
                var user = respond.result;
                //@@@@@@@@@@@@@@@@@@@@@ Check and Change username and sessionKey
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);

                return user;
            },function(reject){
                return 'error';
            });
    }

    function signOut() {
        //no need of promise for right now. Just for the code to be consistent and reusable
        var promise = new Promise(function (resolve, reject) {
            localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
            localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);

            resolve();
        })

        return promise;
    }

    function hasUser() {
        return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) && !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
    }

    /*COOKIES*/
    function cookiesGet() {
        return jsonRequester.get('api/cookies')
            .then(function(res) {
                return res;
            });
    }


    function cookiesGetByCategory(category) {
        return jsonRequester.get('api/cookies')
            .then(function(res) {
                res=_.filter(res,function(cookie){
                    return cookie.category===category;
                })

                return res;
            });
    }

    function likeOrDislikeCookie(id,type){
        var headers= {
            'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
        }
        console.log('auth-key: '+localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY))
        var data={
            type:type
        }

        var options={
            data:data,
            headers:headers
        }

        return jsonRequester.put('api/cookies/'+id,options)
            .then(function(res) {
                return res;
            });
    }

    function addCookie(cookie) {
        var options = {
            data: cookie,
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };

        return jsonRequester.post('api/cookies', options)
            .then(function(resp) {
                return resp;
            });
    }

    function getHourlyCookie() {
        var options = {
            headers: {
                'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };

        return jsonRequester.get('api/my-cookie',options)
            .then(function(res) {
                console.log(res)
                console.log(res.result)
                return res;
            });
    }

    return {
        users: {
            signIn: signIn,
            signOut: signOut,
            register: register,
            hasUser: hasUser,
        },
        cookies:{
            get:cookiesGet,
            getByCategory:cookiesGetByCategory,
            likeOrDislike:likeOrDislikeCookie,
            add:addCookie,
            getHourlyCookie:getHourlyCookie
        }
    };
}());

