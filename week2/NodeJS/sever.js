
var websocker = require('ws');

var callbackInitSever=()=>{
    console.log("Cuddo Sever is running.");
}

var wss  = new websocker.Server({port:5500},callbackInitSever)

var wsList = [];
wss.on("connection",(ws)=>{
    
    console.log("client connected.");
    wsList.push(ws);

    ws.on("message",(data)=>{
        console.log("send from client :"+ data)
        Boardcast(data);
    })

    ws.on("close", ()=>{
        console.log("client disconnected.")
        wsList=ArrayRemove(wsList,ws);
    })


});

function ArrayRemove(arr, value)
{
    return arr.filter((element)=>{
        return element != value;

    });
}


function Boardcast(data)
{
    for(var i=0 ;i<wsList.length;i++)
    {
        wsList[i].send("["+i+"]" + data);
        
    }

}

/*function test(a,callback)
{
    callback();

}
var callbackTest= ()=>{

}
test(5,callbackTest);*/