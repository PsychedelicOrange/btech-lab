const express = require('express');
const bodyParser = require('body-parser');
const cookieParser = require('cookie-parser');
const sqlite3 = require('sqlite3').verbose();

const app = express();
const db = new sqlite3.Database('users.db');

app.use(bodyParser.urlencoded({ extended: true }));
app.use(cookieParser());
app.use(express.static('dist'));
db.serialize(() => {
    db.run(`
      CREATE TABLE IF NOT EXISTS users (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        username TEXT NOT NULL UNIQUE,
        password TEXT NOT NULL
      )
    `);
  });

app.get('/', (req, res) => {
    res.redirect('/login');
  });
// Signup POST route
app.get('/signup', (req, res) => {
  var username = req.get('username');
  var password = req.get('password');
  console.log(JSON.stringify(req.headers));

  db.run('INSERT INTO users (username, password) VALUES (?, ?)', [username, password], (err) => {
    if (err) {
      res.status(400).send('Error creating user');
    } else {
      res.status(200).send('Success');
    }
  });
});

// Login route
app.get('/login', (req, res) => {
  res.sendFile( __dirname + "/" + "dist/login.html" );
});

app.get('/login/check', (req, res) => {
  console.log('requested')
  var username = req.get('username');
  var password = req.get('password');
  db.get('SELECT * FROM users WHERE username = ? AND password = ?', [username, password], (err, row) => {
    if (err || !row) {
      res.status(401).send('Invalid username or password');
    } else {
      res.cookie('userId', row.id);
      res.status(200).send('success');
    }
  });
});

// Start server
app.listen(3000, () => console.log('Server started on port 3000'));
