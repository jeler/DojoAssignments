function randomChance(quarters) {
    var count = 0;
    while(quarters > 0) {
        var slotResult = Math.floor(Math.random() * 100) + 1; //chance of winning
        var winnings = Math.floor(Math.random()*50) + 50 //amount of winnings
        var winningNumber = Math.floor(Math.random()*100) + 1 //winning number
        console.log(winningNumber)
        if(slotResult === winningNumber) {
            quarters+=winnings;
            console.log("yay winning!")
            return quarters;
        }
        else {
        quarters--;
        count++;
        }
    console.log(count);
    }
}
console.log(randomChance(1500));

function randomChance2(quarters)
{
    for(var i = quarters; i>0; i--)
    {
        var number = Math.floor(Math.random()*100) +1
        if(number === 100)
        {
            console.log("winning")
            return quarters;
        }
    }
    return "NOPE"
}

randomChance2(100)