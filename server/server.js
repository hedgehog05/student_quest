const express = require("express");
const app = express();
const mongoose = require('mongoose');

require('./model/Ratingline');
const Ratingline = mongoose.model('ratingLines');

const { MongoClient } = require("mongodb");

const uri = process.env.MONGODB_URI;
mongoose.connect(uri, {useNewUrlParser: true, useUnifiedTopology: true});
// use the express-static middleware
//app.use(express.static("public"));

// define the first route
app.get('/rline', async (req,res) => {
  const client = new MongoClient(uri, { useUnifiedTopology: true });
  
  try {
    //await client.connect();

    const {rusername, rscore} = req.query;
        var ratLine = await Ratingline.findOne({username: rusername, score: rscore});
        if (ratLine == null ){
            var newRline = new Ratingline({
                username: rusername,
                score: rscore
            });
            await newRline.save();
        }
        var result = await Ratingline.find({},{_id:0}).sort({"score":-1}).limit(10);
        console.log(result); //в консоль баш
        res.send(result);
        //res.send("beb");
        //res.send(newRline); //выводит на веб-страницу
        return;

    
  } catch(err) {
    console.log(err);
  }
  //finally {
    // Ensures that the client will close when you finish/error
    //await client.close();
  //}
});

// start the server listening for requests
app.listen(process.env.PORT || 3000, 
	() => console.log("Server is running..."));

// const mongoose = require('mongoose');
// const {Schema} = mongoose;

// const ratingSchema = new Schema({
//     username: String,
//     score: Number,
// });

// mongoose.model('ratingLines', ratingSchema);
