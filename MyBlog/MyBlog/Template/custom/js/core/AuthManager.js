function AuthManager(firebase)
{
    PrintLogMessage("AuthManager", "AuthManager", "init", LOG_LEVEL_INFO)
    this.firebase = firebase
}

AuthManager.prototype.SignUp = function ()
{
    PrintLogMessage("AuthManager", "SignUp", "start google sign up", LOG_LEVEL_INFO)
}

AuthManager.prototype.SignIn = function ()
{
    PrintLogMessage("AuthManager", "SignIn", "start google sign in", LOG_LEVEL_INFO)

    provider = new this.firebase.auth.GoogleAuthProvider();
    this.firebase.auth().signInWithPopup(provider)
        .then(function (result)
        {
            PrintLogMessage("AuthManager", "SignIn", "sign in successfully user: " + JSON.stringify(result.user) + " token: " + result.credential.accessToken, LOG_LEVEL_DEBUG)
        })
        .catch(function (error)
        {
            PrintLogMessage("AuthManager", "SignIn", "error while sign in code: " + error.code + " msg: " + error.message + " email: " + error.email, LOG_LEVEL_ERROR)
        })
}

AuthManager.prototype.CurrentAuthStatus = function()
{
    PrintLogMessage("AuthManager", "CurrentAuthStatus", "set auth status change listener", LOG_LEVEL_INFO)

    this.firebase.auth().onAuthStateChanged(function(currentUser)
    {
        if (currentUser)
        {
            PrintLogMessage("AuthManager", "CurrentAuthStatus", "user signed in: " + JSON.stringify(currentUser), LOG_LEVEL_DEBUG)
        }
        else
        {
            PrintLogMessage("AuthManager", "CurrentAuthStatus", "user not signed in", LOG_LEVEL_INFO)
        }
    })
}