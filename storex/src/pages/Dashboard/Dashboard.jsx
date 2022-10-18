import React from 'react'
import Header from '../../components/Header/Header'
import Sidebar from '../../components/Sidebar/Sidebar'
import DashboardGrid from '../../components/DashboardGrid/DashboardGrid'
import styled from 'styled-components'

const Dashboard = () => {
  return (
    <Dashboard_Session>
      <Sidebar />
      <div style={{width:"86%"}}>
        <Header />
        <DashboardGrid/>
      </div>
    </Dashboard_Session>
  )
}

const Dashboard_Session = styled.div`
    display: flex;
    height: 100%;
`

export default Dashboard;

