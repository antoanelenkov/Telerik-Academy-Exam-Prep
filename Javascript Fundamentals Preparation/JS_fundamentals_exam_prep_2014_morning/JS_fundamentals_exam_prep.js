//2014.01.Vehicles
function solve1(params) {
    var s = parseInt(params[0]),
        count = 0,
        motor = 3,
        car = 4,
        truck = 10;

    for (var i = 0; i <= s; i += motor) {
        for (var j = 0; j <= s; j += car) {
            for (var k = 0; k <= s; k += truck) {
                if ((i + j + k) === s) {
                    count++;
                }
            }
        }
    }
    console.log(count);
}
//result 100/100

//2014.02.Paths.
function solve2(params) {
    var rowsAndCols = params[0].split(' '),
        matrix = [],
        directions = [];
    matrix.length = parseInt(rowsAndCols[0]);
    directions.length = matrix.length;

    for (var i = 0; i < matrix.length; i += 1) {
        matrix[i] = [];
        matrix[i].length = parseInt((rowsAndCols[1]));
        directions[i] = [];
        directions[i].length = matrix[i].length;
    }

    for (var i = 0; i < matrix.length; i += 1) {
        var count = Math.pow(2, i);
        var dirs = params[i + 1].split(' ');
        for (var j = 0; j < matrix[i].length; j += 1) {
            matrix[i][j] = count++;
            directions[i][j] = dirs[j];
        }
    }

    var row = 0,
        col = 0,
        prevRow = 0,
        prevCol = 0,
        sum = 0;

    while (true) {
        if (row < 0 || row >= matrix.length || col < 0 || col >= matrix[0].length) {
            console.log('successed with ' + sum);
            return;
        }
        else if (directions[row][col] === 0) {
            console.log('failed at ' + '(' + row + ', ' + col + ')');
            return;
        }
        else {
            sum += matrix[row][col];
            prevCol = col;
            prevRow = row;

            switch (directions[row][col]) {
                case 'ur':
                    row--;
                    col++;
                    break;
                case 'ul':
                    row--;
                    col--;
                    break;
                case 'dr':
                    row++;
                    col++;
                    break;
                case 'dl':
                    row++;
                    col--;
                    break;
            }

            directions[prevRow][prevCol] = 0;
        }
    }
}

var args = [
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
]
solve2(args);
//result - 100/100

function solve3(params) {
    var objectCount = parseInt(params[0]);
    var object = [];
    for (var i = 0; i < objectCount; i += 1) {
        var key_value = params[i + 1].split(':');
        object[key_value[0]] = key_value[1];
    }
    var lengthOfText = parseInt(params[objectCount + 1]);

    var input = '';
    for (var i = 0; i < lengthOfText; i += 1) {
        input = input + params[i + objectCount + 2].trimLeft() + '\n';
    }

    //console.log(input);

    var words = [];
    var conditions = [];
    var forEachs=[];

    for (var item in object) {
        if(((object[item].indexOf(',')>=0)||object[item]==='false')||(object[item]==='true')){
            //booleans
            if (object[item]==='false'||object[item]==='true') {
                conditions[item] = object[item];
            }
            //arrays
            if((object[item].indexOf(',') >= 0)){
                forEachs[item]=object[item].split(',');
            }
        }
        //regular words
        else {
            words[item] = object[item];
        }
    }

    var output=input;




    for(var section in sections){
        //console.log(sections[section]);
        output=output.replace(sections[section],'').trim();
    }
    //console.log(output);

    //escaping
    while(output.indexOf('@@')>0){
        output=output.replace('@@','@');
    }

    //pure text
    for(var word in words){
        var index = 0;
        do {
            output=output.replace('@'+word,words[word]);
        } while((index = output.indexOf('@'+word, index + 1)) > -1);
    }

    //conditions
    for(var condition in conditions){
        if(conditions[condition]==='false'){
            var startIndex=output.indexOf('@if ('+condition+')');
            var finalIndex=output.indexOf('}',startIndex);
            var substrToDelete=output.substring(startIndex,finalIndex+2);
            output=output.replace(substrToDelete,'');
        }
        else{
            var startIndex=output.indexOf('@if ('+condition+')');
            var finalIndex=output.indexOf('}',startIndex);
            var startIndexOfcontent=output.indexOf('<',startIndex);
            var finalIndexOfcontent=finalIndex-1;
            var inputString=output.substring(startIndexOfcontent,finalIndexOfcontent+1);
            //inputString=inputString.replace('@'+);
            var substrToDelete=output.substring(startIndex,finalIndex+2);
            output=output.replace(substrToDelete,inputString);
        }
    }

    //for-each
    for(var forEach in forEachs){
        var startIndex=output.indexOf('@foreach (var '+forEach.substring(0,forEach.length-1));
        var finalIndex=output.indexOf('}',startIndex);
        var startIndexOfcontent=output.indexOf('<',startIndex);
        var finalIndexOfcontent=finalIndex-1;
        var allInput='';
        if(startIndex===-1){
            continue;
        }
        for(var i=0;i<forEachs[forEach].length;i+=1){
            var inputString=output.substring(startIndexOfcontent,finalIndexOfcontent+1);
            inputString=inputString.replace('@'+forEach.substr(0,forEach.length-1),forEachs[forEach][i]);
            allInput+=inputString;
        }
        var substrToDelete=output.substring(startIndex,finalIndex+2);
        output=output.replace(substrToDelete,allInput);
    }


    //render sections
    var html='<!DOCTYPE html>';
    var sections=[];

    var firstIndexSections=output.indexOf('@section');
    var lastIndexSections=output.indexOf('}',firstIndexSections);
    while((firstIndexSections > -1&&firstIndexSections<output.indexOf(html))){
        var content=output.substring(firstIndexSections,lastIndexSections+1);
        sections.push(content);
        firstIndexSections = output.indexOf('@section',firstIndexSections+1);
        lastIndexSections=output.indexOf('}',firstIndexSections);
    }
    for(var section in sections){
        var firstIndexOfItem=8;
        var lastIndexOfItem=sections[section].indexOf(' ',10);
        //console.log()
        var item=sections[section].substring(firstIndexOfItem+1,lastIndexOfItem);
        output=output.replace(sections[section],'').trim();


        var startIndex=output.indexOf('@renderSection("'+item+'")');
        //console.log(startIndex);
        //console.log('@renderSection("'+item+'")');
        var finalIndex=output.indexOf(')',startIndex);
        //console.log(finalIndex);
        var substrToDelete=output.substring(startIndex-1,finalIndex+1);
        //console.log(output.substring(startIndex,finalIndex+1));
        output=output.replace(substrToDelete,(sections[section].substring(lastIndexOfItem+2,sections[section].length-2)));
    }
//console.log('--------------')
    console.log(output);
}

solve3([
    '6',
    'title:Telerik Academy',
    'showSubtitle:true',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
    '@section menu {',
    '<ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '}',
    '@section footer {',
    '<footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '}',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    @renderSection("menu")',
    '',
    '    <h1>@title</h1>',
    '    @if (showSubtitle) {',
    '        <h2>@subTitle</h2>',
    '        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '    }',
    '',
    '    <ul>',
    '        @foreach (var student in students) {',
    '            <li>',
    '                @student ',
    '            </li>',
    '            <li>Multiline @title</li>',
    '        }',
    '    </ul>',
    '    @if (showMarks) {',
    '        <div>',
    '            @marks',
    '        </div>',
    '    }',
    '',
    '    @renderSection("footer")',
    '</body>',
    '</html>'
]);
//40/100

var bonus=function(p){return p[0]*p[1]>0?p[0]>0?1:2:p[0]<0?0:3};
//25/25