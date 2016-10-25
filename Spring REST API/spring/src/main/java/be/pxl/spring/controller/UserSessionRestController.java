package be.pxl.spring.controller;

import java.sql.Timestamp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.spring.domain.User;
import be.pxl.spring.service.UserService;

@RestController
@RequestMapping(value="/usersession", produces="application/json")
public class UserSessionRestController {

	@Autowired
	UserService us;
	
	@RequestMapping(method = RequestMethod.GET, value="{id}")
	public ResponseEntity<User> getUserSessionById(@PathVariable("id") int id){
		HttpStatus status;
		User u = us.findOne(id);
		if(u == null){
			status = HttpStatus.NOT_FOUND;		
		}else{				
			status = HttpStatus.OK;
		}
		return new ResponseEntity<User>(u, status);		
	}	
	@RequestMapping(method = RequestMethod.POST, value = "ByDate/{id}")
	public ResponseEntity<User> getUserSessionByDate(@PathVariable("id")int id, @RequestBody Timestamp timeStamp){
		HttpStatus status;
		User u = us.findByDate(id, timeStamp);
		if(u == null){
			status = HttpStatus.NOT_FOUND;		
		}else{				
			status = HttpStatus.OK;
		}
		return new ResponseEntity<User>(u, status);	
		
	}
	
	@RequestMapping(method = RequestMethod.POST, value = "ByGreaterStart/{id}")
	public ResponseEntity<User> getUserSessionByGreaterStartTime(@PathVariable("id")int id, @RequestBody Timestamp timeStamp){
		User u = us.findByGreaterStartTime(id, timeStamp);
		HttpStatus status;
		if(u == null){
			status = HttpStatus.NOT_FOUND;		
		}else{				
			status = HttpStatus.OK;
		}
		return new ResponseEntity<User>(u, status);	
		
		
	}
	@RequestMapping(method = RequestMethod.POST, value = "ByLesserEnd/{id}")
	public ResponseEntity<User> getUserSessionByLesserEndTime(@PathVariable("id") int id, @RequestBody Timestamp timeStamp){
		User u = us.findByLesserEndTime(id, timeStamp);
		HttpStatus status;
		if(u == null){
			status = HttpStatus.NOT_FOUND;		
		}else{				
			status = HttpStatus.OK;
		}
		return new ResponseEntity<User>(u, status);	
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByGreaterActual/{id}/{time}")
	public ResponseEntity<User> getUserSessionByGreaterActualTime(@PathVariable("id") int id, @PathVariable("time") int time){
		
		User u = us.findByGreaterActualTime(id, time);
		HttpStatus status;
		if(u == null){
			status = HttpStatus.NOT_FOUND;		
		}else{				
			status = HttpStatus.OK;
		}
		return new ResponseEntity<User>(u, status);	
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByLesserActual/{id}/{time}")
	public ResponseEntity<User> getUserSessionByLesserActualTime(@PathVariable("id") int id, @PathVariable("time") int time){
		User u = us.findByLesserActualTime(id, time);
		HttpStatus status;
		if(u == null){
			status = HttpStatus.NOT_FOUND;		
		}else{				
			status = HttpStatus.OK;
		}
		return new ResponseEntity<User>(u, status);	
		
	}
	@RequestMapping(method = RequestMethod.POST, value = "Between/{id}")
	public ResponseEntity<User> getUserSessionBetween(@PathVariable("id") int id, @RequestBody Timestamp startTime,
			@RequestBody Timestamp endTime ){	
		
		
		User u = us.findBetween(id, startTime, endTime);
		HttpStatus status;
		if(u == null){
			status = HttpStatus.NOT_FOUND;		
		}else{				
			status = HttpStatus.OK;
		}
		return new ResponseEntity<User>(u, status);	
		
	}
	
	@RequestMapping(method = RequestMethod.POST, value="AverageActualTimeBetween/{id}")
	public double getAverageActualTime(@PathVariable("id") int id, @RequestBody Timestamp startTime,
			@RequestBody Timestamp endTime ){
		
				return us.getAverageActualTime(id, startTime, endTime);
		
	}
	@RequestMapping(method = RequestMethod.GET, value="AverageActualTime/{id}")
	public double getAverageActualTime(@PathVariable("id") int id){
		
				return us.getAverageActualTime(id);
		
	}
	@RequestMapping(method = RequestMethod.GET, value="MinimalActualTime/{id}")
	public int getMinimalActualTime(@PathVariable("id") int id){
		return us.getMinimalActualTime(id);
	}
	@RequestMapping(method = RequestMethod.GET, value="MinimalActualTimeBetween/{id}")
	public int getMinimalActualTime(@PathVariable("id") int id, @RequestBody Timestamp startTime,
			@RequestBody Timestamp endTime ){
		return us.getMinimalActualTime(id, startTime, endTime);
	}
	@RequestMapping(method = RequestMethod.GET, value="MaximalActualTime/{id}")
	public int getMaximalActualTime(@PathVariable("id") int id){
		return us.getMaximalActualTime(id);
	}
	@RequestMapping(method = RequestMethod.POST, value="MaximalActualTimeBetween/{id}")
	public int getMaximalActualTimeBetween(@PathVariable("id") int id, @RequestBody Timestamp startTime,
			@RequestBody Timestamp endTime ){
		return us.getMaximalActualTime(id, startTime, endTime);
	}
}
