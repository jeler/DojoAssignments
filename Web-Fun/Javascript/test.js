function findMaxAndAvg(arr) {
    var max = arr[0];
    var sum = 0;
    for(var i = 0; i < arr.length; i++) {
        if(arr[i] > max) {
            max= arr[i];
        }
        sum+=arr[i];
    }
    console.log("The average is" + " " + sum/arr.length)
    console.log ("The max is" + " " + max);
}
findMaxAndAvg([2,4,7,6,4,2,10]);