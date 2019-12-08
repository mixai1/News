import React, { Component } from 'react';
import { Table, Col, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import { connect } from 'react-redux';
import * as repositoryActions  from '../../../store/actions/repositoryActions';
import News from '../../../components/NewsComponents/News/News';

class NewsList extends Component {

    componentDidMount = () => {
        let url = '/api/news';
        this.props.onGetData(url, { ...this.props });
    }

    render() {
        let newslist = [];
        if (this.props.data && this.props.data.length > 0) {
            newslist = this.props.data.map((news) => {
                return (
                    <News key={news.id} news={news} {...this.props} />
                )
            })
        }
        return (
            <Aux>
                <Row>
                    <Col mdOffset={10} md={2}>
                        <Link to='/create' >Create</Link>
                    </Col>
                </Row>
                <br />
                <Row>
                    <Col md={12}>
                        <Table responsive striped>
                            <thead>
                                <tr>
                                    <th>Titel</th>
                                    <th>Body</th>
                                    <th>Address</th>
                                    <th>Details</th>
                                    <th>Update</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                                {newslist}
                            </tbody>
                        </Table>
                    </Col>
                </Row>
            </Aux>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        data: state.data
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        onGetData: (url, props) => dispatch(repositoryActions.getData(url, props))
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(NewsList);