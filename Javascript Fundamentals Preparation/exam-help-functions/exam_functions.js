//indexOf for more than one occurrences
function myIndexOf(text, subString) {
    var indexOccurrences = [];
    var index = text.indexOf(subString);
    //check for first match
    if (index === -1) {
        return indexOccurrences;
    }

    while (index > -1) {
        indexOccurrences.push(index);
        index = text.indexOf(subString, index + 1);
    }
    return indexOccurrences;
}

var string = 'asd 5asd  56asd   56';
console.log(myIndexOf(string, 'asd'));

//myContains
String.prototype.myContains = function (subString) {
    return this.indexOf(subString)===-1?false:true;
}

console.log(string.myContains('asd'));

String.prototype.myReplaceAll=function(stringToReplace,newString){
    return this.split(stringToReplace).join(newString);
}

console.log(string.myReplaceAll('5',4));

