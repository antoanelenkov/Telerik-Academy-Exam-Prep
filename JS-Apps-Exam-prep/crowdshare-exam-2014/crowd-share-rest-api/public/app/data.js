var data = (function() {
    const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
        LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

    /* Users */

    function register(user) {
        var reqUser = {
            username: user.username,
            authCode: CryptoJS.SHA1(user.username + user.password).toString()
        };

        return jsonRequester.post('/user', {
            data: reqUser
        })
            .then(function(isSuccessful) {

                return {
                    isSuccessful: isSuccessful
                };
            },function(error){
                return error;
            });
    }


    function signIn(user) {
        var reqUser = {
            username: user.username,
            authCode: CryptoJS.SHA1(user.username + user.password).toString()
        };

        var options = {
            data: reqUser
        };

        return jsonRequester.post('/auth', options)
            .then(function(respond){
                var user = respond;
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.sessionKey);

                return user;
            });
    }

    function signOut() {
        var reqHeaders = {
            'x-sessionkey': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
        };
        var options = {
            headers: reqHeaders
        };

        return jsonRequester.put('/user', options)
            .then(function(respond) {
                var isSuccessful = respond;
                localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
                localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
                return isSuccessful;
            });
    }

    function hasUser() {
        return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) &&
            !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
    }

    /* posts */
    function postAdd(post) {
        var options = {
            data: post,
            headers: {
                'X-SessionKey': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
            }
        };

        return jsonRequester.post('/post', options)
            .then(function(resp) {
                return resp;
            });
    }

    function postsGet(username,pattern) {
        //Query String - 2. check for the query strings
        var queryString='?';
        if(username){
            queryString+='user='+username+'&';
        }
        if(pattern){
            queryString+='pattern='+pattern+'&';
        }
        return jsonRequester.get('/post'+queryString)
            .then(function(res) {
                return res;
            });
    }

    return {
        users: {
            signIn:signIn,
            signOut:signOut,
            register:register,
            hasUser:hasUser,
        },
        posts: {
            get: postsGet,
            add: postAdd,
        }
    };
}());

