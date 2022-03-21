import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'

export default function Home() {
  return (
    <div className={styles.container}>
      <h1>Hello!!!</h1>
      <div className={styles.circles}>
        <p>hi!</p>
      </div>
    </div>
  )
}
