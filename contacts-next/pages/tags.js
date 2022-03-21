// import styles from '../styles/tanks.module.css'
import instance from "../lib/instance";
import { useEffect, useState } from "react"

const Tag = () => {

  const [tags, setTags] = useState(null);
  const [counter, setCounter] = useState(0);

  useEffect(() => {
    instance.get('tag')
    .then((result) => {
      setTags(JSON.parse(result.data))
    })
    .catch((result) => {
      console.log(result);
    })
  }, []);

  return (
    <div>
      <table border="1px" width="100%" cellspacing="10" cellpadding="10">
        <thead>
          <tr>
            <th>Идентификатор</th>
            <th>Наименование</th>
          </tr>
        </thead>
        <tbody>
          
          {tags && tags.map(tag =>
              <tr key={tag.idTag}>
                <td>{counter += 1}</td>
                <td>{tag.caption}</td>
              </tr>
              )}

          

        </tbody>
      </table>
    </div>
  )
}

export default Tag