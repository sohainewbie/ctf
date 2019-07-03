const express = require('express');
const app = express();
const crypto = require('crypto');
const jwt = require('jsonwebtoken');
const cookieParser = require('cookie-parser');
const { exec } = require('child_process');
const bodyParser = require('body-parser');

/*
how to setup

npm install --save express
npm install --save jsonwebtoken
npm install --save cookie-parser

node challange.js
*/

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.use(cookieParser());


function generateKey() {

    const date = new Date();
    const year = date.getFullYear();

    let month = date.getMonth() + 1;
    month = (month < 10 ? "0" : "") + month;

    let day  = date.getDate();
    day = (day < 10 ? "0" : "") + day;
    let key = `${year}:${month}:${day}:LevelUP!`;

    return crypto.createHash('md5').update(key).digest("hex");
}

function decodeValue(token, key) {
    try {
        return jwt.verify(token, key, function (err, decoded) {
            return decoded.isAdmin
        });
    }
    catch(err) {
        return false;
    }
}

app.get('/', function(req, res) {
    if(req.headers['user-agent'] === 'LevelUP!' && decodeValue(req.cookies.auth, generateKey())) {
        res.render('game.ejs');
    } else {
        res.send("You are not authorized!");
    }
});


app.post('/levelUp', function(req, res) {
    if(req.headers['user-agent'] === 'LevelUP!' && decodeValue(req.cookies.auth, generateKey())) {
        const level = req.body.level;
        exec('./levelup ' + level, (err, stdout) => {
            res.send(stdout)
        });
    } else {
        res.send("You are not authorized!");
    }

});
app.listen(5000, '127.0.0.1',
    () => console.log(`Example app listening on port 5000!`));
