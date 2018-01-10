function printRange(start,end,skip) 
{
    for(var i = start; i<end; i+=skip) 
    {
        if(skip === undefined) {
            skip = 1;
        }
        if (end === undefined) {
            var temp = start;
            start = 0;
            end = temp;
        }
        console.log(i);
    }

}
printRange(4);