"use client"

import Image from "next/image";
import styles from "./page.module.css";
import { useEffect, useState } from "react";

export default function Home() {
  
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const res = await fetch("http://localhost:5031/games");
      const data = await res.json();
      console.log(data);
      setData(data);
    }

    fetchData();
  
  }, [])

  

  return (
    <div>
      <h1>Games</h1>

      <div className={styles.grid}>
        {data && data.map((game : any) => (
          <div key={game.id} className={styles.card}>
            <h3>{game.name}</h3>
            <p>{game.description}</p>
          </div>
        ))}

        </div>

    </div>
  );
}
