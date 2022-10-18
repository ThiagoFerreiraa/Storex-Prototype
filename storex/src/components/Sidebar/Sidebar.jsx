import React from 'react'
import './Sidebar.css'
import { Link } from 'react-router-dom'

const Sidebar = () => {
  return (
    <div className='container_sidebar'>
      <div className='container title'>
        <h1>
          <Link to="../dashboard">
            <a href="">STOREX</a>
          </Link>
        </h1>
      </div>
      <div className='container sidebar_bar'>
        <ul>
          <li>
            <Link to="registration_user">
              <a href="">Storege <i class="bi bi-box-fill"></i></a>
            </Link>
          </li>
          <li>
            <Link to="registration_user">
              <a href="">Sales Orders <i class="bi bi-receipt-cutoff"></i></a>
            </Link>
          </li>
          <li>
            <Link to="../client">
              <a href="">Clients <i class="bi bi-person-check-fill"></i></a>
            </Link>
          </li>
          <li>
            <Link to="../user">
              <a href="">Users <i class="bi bi-person-plus-fill"></i></a>
            </Link>
          </li>
          <li>
            <Link to="../distribuidors">
              <a href="">Distributors <i class="bi bi-building"></i></a>
            </Link>
          </li>
        </ul>
      </div>
      <div className='container logoutDiv'>
        <Link to="/">LOGOUT <i class="bi bi-box-arrow-left"></i></Link>
      </div>
    </div>
  )
}

export default Sidebar