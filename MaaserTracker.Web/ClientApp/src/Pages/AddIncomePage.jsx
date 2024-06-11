import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Container, TextField, Button, Autocomplete, Typography } from '@mui/material';
import dayjs from 'dayjs';
import { useNavigate } from 'react-router-dom';



const AddIncomePage = () => {

    const navigate = useNavigate()

    const [date, setDate] = useState(dayjs(new Date()).format('YYYY-MM-DD'));

    const [sources, setSources] = useState([]);

    const [source, setSource] = useState();

    const [amount, setAmount] = useState()

    useEffect(() => {
        const getSources = async () => {
            const { data } = await axios.get('/api/maaser/getsources');
            setSources(data);
        }

        getSources()
    }, [])

    const onButtonClick = () => {
        axios.post('/api/maaser/addincome', { source: source, amount: amount, dat: date })
        navigate('/income')
    }

    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Income
            </Typography>
            <Autocomplete
                options={sources}
                getOptionLabel={(option) => option.label}
                fullWidth
                margin="normal"
                onChange={(e, value) => value == null ? setSource(null) : setSource(value.label)}
                renderInput={(params) => <TextField {...params} label="Source" variant="outlined" />}
            />
            <TextField
                label="Amount"
                variant="outlined"
                type="number"
                InputProps={{ inputProps: { min: 0, step: 0.01 } }}
                fullWidth
                margin="normal"
                onChange={e => setAmount(e.target.value)}
            />
            <TextField
                label="Date"
                type="date"
                value={dayjs(date).format('YYYY-MM-DD')}
                onChange={e => setDate(e.target.value)}
                renderInput={(params) => <TextField {...params} fullWidth margin="normal" variant="outlined" />}
            />
            <Button variant="contained" color="primary" onClick={onButtonClick}>Add Income</Button>
        </Container>
    );
}

export default AddIncomePage;