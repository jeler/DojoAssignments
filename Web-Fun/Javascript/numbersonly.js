function numbersOnly(arr) {
    var newArray=[];
    for (var i =0; i<arr.length; i++) {
        if (typeof arr[i] === "number") {
            newArray.push(arr[i]);
        }
        else {
            for(var j = arr.length; j > 0; j--){
                arr.splice(1, 0)
                j--;
            }
        }
    }
    console.log(newArray);
}
numbersOnly([2,"3","frog",5]);