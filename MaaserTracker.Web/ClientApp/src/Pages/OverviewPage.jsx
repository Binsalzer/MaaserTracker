import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Container, Typography, Box, Paper } from '@mui/material';

const OverviewPage = () => {

    const [incomeTotal, setIncomeTotal] = useState();
    const [maaserTotal, setMaaserTotal] = useState();



    useEffect(() => {
        const getIncomeTotal = async () => {
            const { data } = await axios.get('/api/maaser/gettotalincome');
            setIncomeTotal(data);
        }

        const getMaaserTotal = async () => {
            const { data } = await axios.get('/api/maaser/gettotalmaaser');
            setMaaserTotal(data);
        }

        getIncomeTotal();
        getMaaserTotal();
    }, [])

    return (
        <Container
            maxWidth="md"
            sx={{
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                height: '80vh',
                textAlign: 'center'
            }}
        >
            <Paper elevation={3} sx={{ padding: '120px', borderRadius: '15px' }}>
                <Typography variant="h2" gutterBottom>
                    Overview
                </Typography>
                <Box sx={{ marginBottom: '20px' }}>
                    <Typography variant="h5" gutterBottom>
                        Total Income: ${`${incomeTotal}`}
                    </Typography>
                    <Typography variant="h5" gutterBottom>
                        Total Maaser: ${`${maaserTotal}`}
                    </Typography>
                </Box>
                <Box>
                    <Typography variant="h5" gutterBottom>
                        Maaser Obligated: ${`${incomeTotal / 10}`}
                    </Typography>
                    <Typography variant="h5" gutterBottom>
                        Remaining Maaser obligation: ${`${incomeTotal / 10 - maaserTotal}`}
                    </Typography>
                </Box>
            </Paper>
        </Container>
    );
}

export default OverviewPage;