import React from 'react'
import './DashboardUsers.css'

const DashboardUsers = (props) => {
  console.log(props.baseData)
  return (
    <div className='container grid'>
      {props.baseData.map(data => (
        <div className='modal_users'>
          <h3>{data.name}</h3>
          <div className='modal_buttons_users'>
            <input type="button" value="Edit" className='btn btn-primary' />
            <input type="button" value="Delete" className='btn btn-danger' />
          </div>
        </div>
      ))}
    </div >
  )
}

export default DashboardUsers