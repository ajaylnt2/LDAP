var ActiveDirectory = require('activedirectory');
var config = {
    url: 'ldap://BRDIESMSDC01.lnties.com',
    baseDN: 'dc=lnties,dc=com',
    username: 'rajasekhara.g@lnttechservices.com',
    password: 'oct@2017'
}
var ad = new ActiveDirectory(config);

var activeDirectory = function () {
    this.abc = function (username, password, callback) {
        var ad = new ActiveDirectory(config);
        var username = username;
        var password = password;

        ad.authenticate(username, password, function (err, auth) {
            if (err) {
                console.log('ERROR: ' + JSON.stringify(err));
                callback(null, JSON.stringify('Authentication failed'));
                return;
            }
            if (auth) {
                ad.findUser(username, function(err, user) {
                if (err) {
                console.log('ERROR: ' + JSON.stringify(err));
                return;
                }
                if ((! user) || (user.length == 0)) console.log('No users found.');
                else {
                  var user_details = JSON.stringify(user);
                callback(null,user_details);
                }
                });
            }
            else {
                //console.log('Authentication failed!');

            }
        });

            }
        };

module.exports = activeDirectory; 