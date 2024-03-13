"use client"

import Image from "next/image";
import styles from "./page.module.css";
import { useEffect, useState } from "react";
import Link from 'next/link'

export default function Home() {
  
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const res = await fetch("http://localhost:5031/games");
      const data = await res.json();
      console.log(data);
      setData(data);
    }
    
    fetchData().catch((e) => console.log(e));
  
  }, [])

  

  return (
    <div>
      <h1>Games</h1>

      <div className={styles.grid}>
        {data && data.map((game : any) => (
          <div key={game.id} className={styles.card}>
              
              <Link href={`/game/${game.id}`}>
                  <h3>{game.name}</h3>
              </Link>

          </div>
        ))}

        </div>

        <div>
          <Link href="/add_game">
            Add Game
          </Link>
        </div>

    </div>
  );
}
