package be.pxl.spring.service;

import java.sql.Timestamp;
import java.util.List;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.RequestEntity;
import org.springframework.stereotype.Service;

import be.pxl.spring.domain.Session;
import be.pxl.spring.repository.SessionRepository;

@Service
@Transactional
public class SessionServiceImpl implements SessionService{
	@Autowired
	private SessionRepository sessionRepo;

	@Autowired
	private SessionUtility averageUtil;
	
	@Override
	@Transactional
	public Session save(Session session)
	{
		return sessionRepo.save(session);
	}
	
	
	@Override
	@Transactional
	public Session findOne(int Id)
	{
		return sessionRepo.findOne(Id);
	}
	
	@Override
	@Transactional
	public List<Session> findByUserId(int userId) {
		
		return sessionRepo.findByUserId(userId);
	}
	
	@Override
	@Transactional
	public List<Session> findByDate(Timestamp timeStamp){
		return sessionRepo.findByDate(timeStamp);
	}
	
	@Override
	@Transactional
	public List<Session> findByGreaterStartTime(Timestamp timeStamp){
		return sessionRepo.findByGreaterStartTime(timeStamp);
	}
	
	@Override
	@Transactional
	public List<Session> findByLesserEndTime(Timestamp timeStamp){
		return sessionRepo.findByLesserEndTime(timeStamp);
	}
	
	@Override
	@Transactional
	public List<Session> findByGreaterActualTime(int time){
		return sessionRepo.findByGreaterActualTime(time);
	}
	
	@Override
	@Transactional
	public List<Session> findByLesserActualTime(int time){
		return sessionRepo.findByLesserActualTime(time);
	}
	
	@Override
	@Transactional
	public List<Session> findBetween(Timestamp startTime, Timestamp endTime) {
		
		return sessionRepo.findBetween(startTime, endTime);
	}

	@Override
	public void flush() {
		
		sessionRepo.flush();
	}

	@Override
	public void delete(Session s) {
		
		sessionRepo.delete(s);
	}

	@Override
	public double getAverageActualTime(Timestamp startTime, Timestamp endTime) {		
		List<Session> sessionList = this.findBetween(startTime, endTime);		
		return averageUtil.AverageActual(sessionList);
	}


	@Override
	public Session getLastSession(int userId) {
		return sessionRepo.findTop1ByUserIdOrderByEndTimeDesc(userId);
	}


	@Override
	public Session getFirstSession(int userId) {
		// TODO Auto-generated method stub
		return sessionRepo.findTop1ByUserIdOrderByStartTimeAsc(userId);
	}

	
}
