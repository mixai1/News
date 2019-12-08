import React from 'react';
import './Navigation.css';
import { Col, Navbar, Nav, NavItem } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import { LinkContainer } from 'react-router-bootstrap';

const navigation = (props) => {
    return (
        <Col md={12} >
             <Navbar inverse collapseOnSelect>
                {/* <Navbar.Header>
                    <Navbar.Brand>
                        <NavLink to={'/home'} exact >News Blog</NavLink>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header> */}
                <Navbar.Collapse>
                    <Nav>
                        <LinkContainer to={'/news-list'} exact>
                            <NavItem eventKey={1}>
                               <button>News Actions</button> 
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={''}>
                            <NavItem eventKey={2}>
                            <button>Comment Actions</button> 
                            </NavItem>
                        </LinkContainer> 
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        </Col>
    )
}

export default navigation;