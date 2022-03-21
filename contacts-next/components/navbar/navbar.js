import styles from "./navbar.module.css";
import React, { useState, useEffect } from "react";
import logo from "../../images/logo.png";
import Image from "next/image";
import Link from 'next/link'

const Navbar = () => {
  return (
    <nav className={styles.navbar}>
      <div className={styles.logo}>
        <Image
          src={logo}
          id="logo"
          alt="Show"
          layout="fixed"
          width="70px"
          height="70px"
        />
      </div>
      <div className={styles.pages}>
        <Link href="/person"><a>Контакты</a></Link>
        <Link href="/tags"><a>Метки</a></Link>
      </div>
    </nav>
  );
};

export default Navbar;
