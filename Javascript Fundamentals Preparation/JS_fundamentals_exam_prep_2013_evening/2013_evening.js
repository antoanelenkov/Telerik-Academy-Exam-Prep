//01.Sequences
function solve1(params){
    var length=params[0]*1;
    var sequence=[];

    for(var i=0;i<length;i+=1){
        sequence[i]=params[i+1]*1;
    }

    var numberOfSequences=1;

    for(var i=1;i<sequence.length;i+=1){
        if(sequence[i-1]<=sequence[i]){
            continue;
        }
        else{
            numberOfSequences++;
        }
    }
    return numberOfSequences;
}

console.log(solve1(['9','1','8','8','7','6','5','7','7','6']));

//02.Joro the naughty
function solve2(params){
    //matrix parser
    var args=params[0].split(' ');
    args=args.map(Number);
    var matrix=[];
    matrix.length=args[0];
    var count=1;

    //fill the matrix with numbers
    for(var i=0;i<matrix.length;i+=1){
        matrix[i]=[];
        matrix[i].length=args[1];
        for(var j=0;j<matrix[i].length;j+=1){
            matrix[i][j]=count++;
        }
    }

    //position parser
    var startPosition=params[1].split(' ');
    var startX=startPosition[0]*1;
    var startY=startPosition[0]*1;

    //sequence parser
    var sequence=[];
    for(var i=2;i<params.length;i+=1){
        sequence[i-2]=params[i].split(' ').map(Number);
    }

    //solution
    var row=startX;
    var col=startY;
    var sum=0;
    var sequenceIteration=0;
    while(true){
        if(row<0||row>=matrix.length||col<0||col>=matrix[0].length){
            return console.log('escaped '+sum);
        }
        else if(matrix[row][col]===0){
            return console.log('caught '+sequenceIteration);
        }
        else{
            sum+=matrix[row][col];
            matrix[row][col]=0;
            row=row+sequence[sequenceIteration%args[2]][0];
            col=col+sequence[sequenceIteration%args[2]][1];
            sequenceIteration++;
        }
    }
}

solve2(['6 7 3','0 0','2 2','-2 2','3 -1']);