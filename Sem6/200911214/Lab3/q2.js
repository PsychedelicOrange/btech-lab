
var forms = document.forms
function onclickSubmit()
{
    var englishPhrase = forms["q2"]["englishPhrase"].value
    var array = englishPhrase.split(' ')
    array.forEach(element => {
        printLatinWord(element)
    });
}
function printLatinWord(word)
{
    let firstLetter = word.at(0);
    word = word.slice (1,word.length)
    word += firstLetter + "ay"
    forms["q2"]["result"].innerHTML += `${word} `
}