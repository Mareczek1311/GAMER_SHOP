"use client"

import { useState } from "react";

const Add_Game = () => {

    const [name, setName] = useState("");
    const [genreId, setGenreId] = useState(0);
    const [image, setImage] = useState("");
    const [price, setPrice] = useState(0);
    const [releaseDate, setReleaseDate] = useState("2021-01-01");

    function add_game_fetch() {
        fetch('http://localhost:5031/games', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: name,
                genreId: genreId,
                Price: price,
                ReleaseDate: releaseDate,                
            })
        })
        .then(response => {
            if (response.ok) {
                console.log("Game added");
            } else {
                console.log("Error adding game");
            }
        })
        .catch((e) => console.log(e));
    }

    return (
        <div>
        <h1>Add Game</h1>
            <label htmlFor="name">Name:</label>
            <input type="text" value={name} onChange={(event) => {
                setName(event?.target.value);
            }} id="name" required />
            <br />
            <label htmlFor="genreid">Genre id(now...):</label>
            <input type="number" value={genreId} onChange={(event) => {
                setGenreId(parseInt(event?.target.value));
            }} id="genreId" required />
            <br />
            <label htmlFor="imageurl">Image Url:</label>
            <input type="text" id="imageurl" required />
            <br />
            <label htmlFor="price">Price:</label>
            <input type="number" id="price" onChange={(event) => {
                setPrice(parseInt(event?.target.value));
            }} required />
            <br />
            <label htmlFor="releasedate">Release Date:</label>
            <input type="date" id="releasedate" onChange={(event) => {
                console.log(event?.target.value);
                setReleaseDate(event?.target.value);
            }} required />
            <br />
            <input type="submit" value="Submit" onClick={() => {add_game_fetch()}} />

        </div>
    );
}

export default Add_Game;